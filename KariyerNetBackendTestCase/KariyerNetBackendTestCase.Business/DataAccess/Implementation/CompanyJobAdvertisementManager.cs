﻿using System;
using System.Linq;
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
    public class CompanyJobAdvertisementManager:ICompanyJobAdvertisementManager
    {
        private readonly ICompanyJobAdvertisementDal _companyJobAdvertisementDal;
        private readonly IJobApplicationManager _jobApplicationManager;
        private readonly IMapper _mapper;

        public CompanyJobAdvertisementManager(ICompanyJobAdvertisementDal companyJobAdvertisementDal, IMapper mapper, IJobApplicationManager jobApplicationManager)
        {
            _companyJobAdvertisementDal = companyJobAdvertisementDal;
            _mapper = mapper;
            _jobApplicationManager = jobApplicationManager;
        }

        [ValidationAspect(typeof(CompanyJobAdvertisementValidator))]
        public IDataResult<CompanyJobAdvertisementDto> Add(CompanyJobAdvertisementDto companyJobAdvertisementDto)
        {
            var request = _mapper.Map<CompanyJobAdvertisement>(companyJobAdvertisementDto);
            request.CreatedTime=DateTimeOffset.Now;
            
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

        public IDataResult<PagedResult<CompanyJobAdvertisement>> GetPagedList(CompanyJobAdvertisementPagedListRequestDto requestDto)
        {
            var result = _companyJobAdvertisementDal.GetPagedList(requestDto.Page, requestDto.PageSize,
                x => x.AdvertisementName.Contains(requestDto.SearchTerm) || x.Description.Contains(requestDto.SearchTerm));

            return new SuccessDataResult<PagedResult<CompanyJobAdvertisement>>(result);
        }

        public IDataResult<int> DeleteById(long companyJobAdvertisementId)
        {

            var rulesResult = BusinessRuleRunner.Run(out var errorMessages, () => CheckIfJobApplicationExists(companyJobAdvertisementId));

            if (rulesResult)
                return new ErrorDataResult<int>(string.Join(",", errorMessages));

            _companyJobAdvertisementDal.MoveToTrash(companyJobAdvertisementId);
            var count = _companyJobAdvertisementDal.Save();

            return new SuccessDataResult<int>(count);
        }

        public IDataResult<bool> CheckCompanyActiveAdvertisement(long companyId)
        {
            var control = _companyJobAdvertisementDal.Exists(x =>
                x.IsActive && x.ExpirationTime >= DateTimeOffset.Now && x.JobApplications.Any());

            return new SuccessDataResult<bool>(control);
        }

        private void CheckIfJobApplicationExists(long companyJobAdvertisementId)
        {
            if(_jobApplicationManager.CheckActiveJobApplicationByJobAdvertisementId(companyJobAdvertisementId).Data);
                throw new Exception("Silmek istediğiniz ilana yeni başvurular yapıldığı için işlem engellendi.");
        }
    }
}
