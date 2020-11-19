using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfUserDal : EntityFrameworkRepositoryBase<User, long>, IUserDal
    {
        public EfUserDal(DbContext context) : base(context)
        {
        }
    }
}
