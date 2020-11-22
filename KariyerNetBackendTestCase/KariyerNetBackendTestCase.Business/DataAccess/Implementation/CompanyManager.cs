using System;
using AutoMapper;
using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Business.Validation;
using KariyerNetBackendTestCase.Core.Aspects.Validation;
using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Business;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Implementation
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyDal _companyDal;
        private readonly ICompanyJobAdvertisementManager _companyJobAdvertisementManager;
        private readonly IMapper _mapper;

        public CompanyManager(ICompanyDal companyDal, IMapper mapper, ICompanyJobAdvertisementManager companyJobAdvertisementManager)
        {
            _companyDal = companyDal;
            _mapper = mapper;
            _companyJobAdvertisementManager = companyJobAdvertisementManager;
        }
        [ValidationAspect(typeof(CompanyValidator))]
        public IDataResult<CompanyDto> Add(CompanyDto companyDto)
        {
            var request = _mapper.Map<Company>(companyDto);
            request.CreatedTime=DateTimeOffset.Now;

            _companyDal.Add(request);
            _companyDal.Save();

            return new SuccessDataResult<CompanyDto>(_mapper.Map<CompanyDto>(request));
        }

        public IDataResult<CompanyDto> GetById(long companyId)
        {
            var result = _companyDal.GetFirstOrDefault(x => x.Id == companyId);

            if (result == null) return new ErrorDataResult<CompanyDto>();

            return new SuccessDataResult<CompanyDto>(_mapper.Map<CompanyDto>(result));
        }
        [ValidationAspect(typeof(CompanyValidator))]
        public IDataResult<CompanyDto> Update(CompanyDto companyDto)
        {
            var requestEntity = _mapper.Map<Company>(companyDto);

            _companyDal.Update(requestEntity);
            _companyDal.Save(); 

            return new SuccessDataResult<CompanyDto>(companyDto);
        }

        public IDataResult<PagedResult<Company>> GetPagedList(CompanyPagedListRequestDto requestDto)
        {
            var result = _companyDal.GetPagedList(requestDto.Page, requestDto.PageSize,
                x => x.CompanyName.Contains(requestDto.SearchTerm) && x.IsDeleted == false);

            return new SuccessDataResult<PagedResult<Company>>(result);
        }

        public IDataResult<int> DeleteById(long companyId)
        {
            var rulesResult = BusinessRuleRunner.Run(out var errorMessages, () => CheckIfCompanyActiveAdvertisementExists(companyId));

            if (rulesResult)
                return new ErrorDataResult<int>(string.Join(",", errorMessages));

            _companyDal.MoveToTrash(companyId);
            var count = _companyDal.Save();

            return new SuccessDataResult<int>(count);
        }

   
        private void CheckIfCompanyActiveAdvertisementExists(long companyId)
        {
            if(_companyJobAdvertisementManager.CheckCompanyActiveAdvertisement(companyId).Data)
                throw new Exception("Firmanın yayında olan ilanları mevcut oluğu için firma silinemez.");
        }
    }
}
