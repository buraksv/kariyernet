using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface IUserCvEducationDal : IQueryableRepository<UserCvEducation,long>, IInsertableRepository<UserCvEducation,long>,  IDeleteableRepository<UserCvEducation,long>,   IUpdateableRepository<UserCvEducation,long> 
    {
    }
}
