using KariyerNetBackendTestCase.Core.DataAccess.Base;
using KariyerNetBackendTestCase.DataAccess.Abstract;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.DataAccess.Implementation
{
    public class EfCompanyDal: EntityFrameworkRepositoryBase<Company,long>, ICompanyDal
    {
        public EfCompanyDal(DbContext context) : base(context)
        {
        }
    }
}
