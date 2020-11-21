using System;
using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfJobApplicationDal : EntityFrameworkRepositoryBase<JobApplication, Guid>, IJobApplicationDal
    {
        public EfJobApplicationDal(DbContext context) : base(context)
        {
        }
    }
}
