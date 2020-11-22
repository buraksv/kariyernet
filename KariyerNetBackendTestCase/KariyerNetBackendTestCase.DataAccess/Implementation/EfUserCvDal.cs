using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfUserCvDal : EntityFrameworkRepositoryBase<UserCv, long>, IUserCvDal
    {
        public EfUserCvDal(KariyerNetBackendTestCaseDbContext context) : base(context)
        {
        }
    }
}
