using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Utilities.Results;
using KariyerNetBackendTestCase.Dto;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.Business.DataAccess.Abstract
{
    public interface ICompanyManager
    {
        IDataResult<CompanyDto> Add(CompanyDto companyDto);
        IDataResult<CompanyDto> GetById(long companyId);
        IDataResult<CompanyDto> Update(CompanyDto companyDto);
        IDataResult<PagedResult<Company>> GetPagedList(CompanyPagedListRequestDto requestDto);
        IDataResult<int> DeleteById(long companyId); 


    }
}
