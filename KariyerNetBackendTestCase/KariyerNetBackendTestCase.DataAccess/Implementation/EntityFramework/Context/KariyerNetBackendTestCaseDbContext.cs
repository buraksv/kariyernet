using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context
{
    public class KariyerNetBackendTestCaseDbContext : DbContext
    {
        public KariyerNetBackendTestCaseDbContext(DbContextOptions<KariyerNetBackendTestCaseDbContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }
    }
}
