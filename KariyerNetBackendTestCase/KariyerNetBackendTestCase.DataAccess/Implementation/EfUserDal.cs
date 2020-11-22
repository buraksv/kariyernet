using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfUserDal : EntityFrameworkRepositoryBase<User, long>, IUserDal
    {
        public EfUserDal(KariyerNetBackendTestCaseDbContext context) : base(context)
        {
        }
    }
}
