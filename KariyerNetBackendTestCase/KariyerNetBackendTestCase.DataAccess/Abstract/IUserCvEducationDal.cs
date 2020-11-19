using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface IUserCvEducationDal : IQueryableRepository<UserCvEducation,long>, IInsertableRepository<UserCvEducation,long>, ITrashableRepository<UserCvEducation,long>, IDeleteableRepository<UserCvEducation,long>, ISwitchableRepository<UserCvEducation,long>, IUpdateableRepository<UserCvEducation,long>, IPageableRepository<UserCvEducation,long>
    {
    }
}
