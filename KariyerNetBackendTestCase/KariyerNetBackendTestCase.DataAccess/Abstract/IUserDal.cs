using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface IUserDal : IQueryableRepository<User,long>, IInsertableRepository<User,long>, ITrashableRepository<User,long>, IDeleteableRepository<User,long>, ISwitchableRepository<User,long>, IUpdateableRepository<User,long>, IPageableRepository<User,long>
    {
    }
}
