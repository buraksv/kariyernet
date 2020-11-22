using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfUserCvWorkingExperienceDal : EntityFrameworkRepositoryBase<UserCvWorkingExperience, long>, IUserCvWorkExperienceDal
    {
        public EfUserCvWorkingExperienceDal(KariyerNetBackendTestCaseDbContext context) : base(context)
        {
        }
    }
}
