using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface ICompanyDal : IQueryableRepository<Company,long>,IInsertableRepository<Company, long>,ITrashableRepository<Company, long>,ISwitchableRepository<Company, long>,IUpdateableRepository<Company, long>,IPageableRepository<Company, long>
    {
    }
}
