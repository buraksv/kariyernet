using System;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Mappings
{
    public class UserCvEducationMappings : IEntityTypeConfiguration<UserCvEducation>
    {
        public void Configure(EntityTypeBuilder<UserCvEducation> builder)
        {
            builder.ToTable("UserCvEducations");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.UserCvId).IsRequired();
            builder.Property(x => x.SchoolLevel).IsRequired().HasConversion<short>();
            builder.Property(x => x.SchoolName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.StartYear).IsRequired();
            builder.Property(x => x.IsAbandoned).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.GradeAverage).IsRequired();
             
 

            builder.HasIndex(x => new { x.UserCvId }).IsClustered(false).HasDatabaseName($"UserCvEducations_Mgr_NCIndex_{DateTime.Now:ddMMyyyy}");
        }
    }
}
