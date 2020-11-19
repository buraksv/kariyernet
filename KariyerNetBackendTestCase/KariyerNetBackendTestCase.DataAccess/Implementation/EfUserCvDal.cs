using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfUserCvDal : EntityFrameworkRepositoryBase<UserCv, long>, IUserCvDal
    {
        public EfUserCvDal(DbContext context) : base(context)
        {
        }
    }
}
