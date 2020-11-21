﻿using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Abstract
{
    public interface ICompanyJobAdvertisementManager
    {
        IDataResult<CompanyJobAdvertisementDto> Add(CompanyJobAdvertisementDto companyJobAdvertisementDto);
        IDataResult<CompanyJobAdvertisementDto> GetById(long companyJobAdvertisementId);
        IDataResult<PagedResult<CompanyJobAdvertisement>> GetPagedList(CompanyPagedListRequestDto requestDto);
        IDataResult<int> DeleteById(long companyJobAdvertisementId);

    }
}
