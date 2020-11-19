using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfCompanyJobAdvertisementDal : EntityFrameworkRepositoryBase<CompanyJobAdvertisement, long>, ICompanyJobAdvertisementDal
    {
        public EfCompanyJobAdvertisementDal(DbContext context) : base(context)
        {
        }
    }
}
