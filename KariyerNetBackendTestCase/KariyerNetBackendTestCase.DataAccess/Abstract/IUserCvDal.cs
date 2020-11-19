using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface IUserCvDal : IQueryableRepository<UserCv,long>, IInsertableRepository<UserCv,long>, ITrashableRepository<UserCv,long>, IDeleteableRepository<UserCv,long>, ISwitchableRepository<UserCv,long>, IUpdateableRepository<UserCv,long>, IPageableRepository<UserCv,long>
    {
    }
}
