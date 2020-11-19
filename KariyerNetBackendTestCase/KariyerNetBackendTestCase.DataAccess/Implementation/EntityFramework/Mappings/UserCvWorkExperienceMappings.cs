using System;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Mappings
{
    public class UserCvWorkExperienceMappings : IEntityTypeConfiguration<UserCvWorkingExperience>
    {
        public void Configure(EntityTypeBuilder<UserCvWorkingExperience> builder)
        {
            builder.ToTable("UserCvWorkingExperiences");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.UserCvId).IsRequired();
            builder.Property(x => x.CompanySector).IsRequired().HasConversion<short>();
            builder.Property(x => x.CompanyName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.WorkDetail).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.CityId).IsRequired();

            builder.HasIndex(x => new { x.UserCvId }).IsClustered(false).HasDatabaseName($"UserCvWorkingExperience_Mgr_NCIndex_{DateTime.Now:ddMMyyyy}");
        }
    }
}
