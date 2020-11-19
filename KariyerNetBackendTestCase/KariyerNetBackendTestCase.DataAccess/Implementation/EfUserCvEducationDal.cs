using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfUserCvEducationDal : EntityFrameworkRepositoryBase<UserCvEducation, long>, IUserCvEducationDal
    {
        public EfUserCvEducationDal(DbContext context) : base(context)
        {
        }
    }
}
