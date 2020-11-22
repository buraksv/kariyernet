using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfCompanyJobAdvertisementDal : EntityFrameworkRepositoryBase<CompanyJobAdvertisement, long>, ICompanyJobAdvertisementDal
    {
        public EfCompanyJobAdvertisementDal(KariyerNetBackendTestCaseDbContext context) : base(context)
        {
        }
    }
}
