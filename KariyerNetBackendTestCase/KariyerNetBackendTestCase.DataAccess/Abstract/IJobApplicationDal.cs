using System;
using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Abstract
{
    public interface IJobApplicationDal : IQueryableRepository<JobApplication, Guid>, IInsertableRepository<JobApplication, Guid>, ITrashableRepository<JobApplication, Guid>, IUpdateableRepository<JobApplication, Guid>, IPageableRepository<JobApplication, Guid>
    {
    }
}
