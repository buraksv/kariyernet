using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface ICompanyJobAdvertisementDal : IQueryableRepository<CompanyJobAdvertisement,long>, IInsertableRepository<CompanyJobAdvertisement,long>, ITrashableRepository<CompanyJobAdvertisement,long>, IDeleteableRepository<CompanyJobAdvertisement,long>, ISwitchableRepository<CompanyJobAdvertisement,long>, IUpdateableRepository<CompanyJobAdvertisement,long>, IPageableRepository<CompanyJobAdvertisement,long>
    {
    }
}
