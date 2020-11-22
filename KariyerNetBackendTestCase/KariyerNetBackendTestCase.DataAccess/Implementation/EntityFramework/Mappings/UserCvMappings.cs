using System;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Mappings
{
    public class UserCvMappings : IEntityTypeConfiguration<UserCv>
    {
        public void Configure(EntityTypeBuilder<UserCv> builder)
        {
            builder.ToTable("UserCv");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.SummaryInformation).HasMaxLength(500);
            builder.Property(x => x.JobTitle).HasMaxLength(250).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.CityId).IsRequired();
            builder.Property(x => x.TownId).IsRequired();
 
            builder.HasIndex(x => new { x.CountryId, x.CityId }).IsClustered(false).HasDatabaseName($"UserCv_Mgr_NCIndex_{DateTime.Now:ddMMyyyy}");
        }
    }
}
