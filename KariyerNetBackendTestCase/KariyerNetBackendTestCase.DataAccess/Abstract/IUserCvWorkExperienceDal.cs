using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface IUserCvWorkExperienceDal : IQueryableRepository<UserCvWorkingExperience,long>, IInsertableRepository<UserCvWorkingExperience,long>,  IDeleteableRepository<UserCvWorkingExperience,long>,  IUpdateableRepository<UserCvWorkingExperience,long> 
    {
    }
}
