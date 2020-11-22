using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfCompanyDal: EntityFrameworkRepositoryBase<Company,long>, ICompanyDal
    {
        public EfCompanyDal(KariyerNetBackendTestCaseDbContext context) : base(context)
        {
        }
    }
}
