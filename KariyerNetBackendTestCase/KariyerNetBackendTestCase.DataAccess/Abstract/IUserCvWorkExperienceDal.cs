using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface IUserCvWorkExperienceDal : IQueryableRepository<UserCvWorkingExperience,long>, IInsertableRepository<UserCvWorkingExperience,long>, ITrashableRepository<UserCvWorkingExperience,long>, IDeleteableRepository<UserCvWorkingExperience,long>, ISwitchableRepository<UserCvWorkingExperience,long>, IUpdateableRepository<UserCvWorkingExperience,long>, IPageableRepository<UserCvWorkingExperience,long>
    {
    }
}
