using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfUserCvEducationDal : EntityFrameworkRepositoryBase<UserCvEducation, long>, IUserCvEducationDal
    {
        public EfUserCvEducationDal(KariyerNetBackendTestCaseDbContext context) : base(context)
        {
        }
    }
}
