using System;
using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using KariyerNetBackendTestCase.Entity;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfJobApplicationDal : EntityFrameworkRepositoryBase<JobApplication, Guid>, IJobApplicationDal
    {
        public EfJobApplicationDal(KariyerNetBackendTestCaseDbContext context) : base(context)
        {
        }
    }
}
