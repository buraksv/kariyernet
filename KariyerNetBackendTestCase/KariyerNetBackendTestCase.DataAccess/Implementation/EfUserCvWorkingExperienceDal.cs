using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfUserCvWorkingExperienceDal : EntityFrameworkRepositoryBase<UserCvWorkingExperience, long>, IUserCvWorkExperienceDal
    {
        public EfUserCvWorkingExperienceDal(DbContext context) : base(context)
        {
        }
    }
}
