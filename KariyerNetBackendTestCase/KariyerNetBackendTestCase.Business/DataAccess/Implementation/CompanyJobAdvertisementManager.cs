using AutoMapper;
using KariyerNetBackendTestCase.Business.DataAccess.Abstract;
using KariyerNetBackendTestCase.Business.Validation;
using KariyerNetBackendTestCase.Core.Aspects.Validation;
using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Implementation
{
    public class CompanyJobAdvertisementManager:ICompanyJobAdvertisementManager
    {
        private readonly ICompanyJobAdvertisementDal _companyJobAdvertisementDal;
        private readonly IMapper _mapper;

        public CompanyJobAdvertisementManager(ICompanyJobAdvertisementDal companyJobAdvertisementDal, IMapper mapper)
        {
            _companyJobAdvertisementDal = companyJobAdvertisementDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CompanyJobAdvertisementValidator))]
        public IDataResult<CompanyJobAdvertisementDto> Add(CompanyJobAdvertisementDto companyJobAdvertisementDto)
        {
            var request = _mapper.Map<CompanyJobAdvertisement>(companyJobAdvertisementDto);

            _companyJobAdvertisementDal.Add(request);
            _companyJobAdvertisementDal.Save();

            return new SuccessDataResult<CompanyJobAdvertisementDto>(_mapper.Map<CompanyJobAdvertisementDto>(request));
        }

        public IDataResult<CompanyJobAdvertisementDto> GetById(long companyJobAdvertisementId)
        {
            var result = _companyJobAdvertisementDal.GetFirstOrDefault(x => x.Id == companyJobAdvertisementId);

            if (result == null) return new ErrorDataResult<CompanyJobAdvertisementDto>();

            return new SuccessDataResult<CompanyJobAdvertisementDto>(_mapper.Map<CompanyJobAdvertisementDto>(result)); 
        }

        public IDataResult<PagedResult<CompanyJobAdvertisement>> GetPagedList(CompanyPagedListRequestDto requestDto)
        {
            var result = _companyJobAdvertisementDal.GetPagedList(requestDto.Page, requestDto.PageSize,
                x => x.AdvertisementName.Contains(requestDto.SearchTerm) || x.Description.Contains(requestDto.SearchTerm));

            return new SuccessDataResult<PagedResult<CompanyJobAdvertisement>>(result);
        }

        public IDataResult<int> DeleteById(long companyJobAdvertisementId)
        {
            _companyJobAdvertisementDal.MoveToTrash(companyJobAdvertisementId);
            var count = _companyJobAdvertisementDal.Save();

            return new SuccessDataResult<int>(count);
        }
    }
}
