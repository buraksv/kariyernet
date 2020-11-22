using System;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Mappings
{
    public class JobApplicationMappings : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("JobApplications");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CompanyJobAdvertisementId).IsRequired();
            builder.Property(x => x.ApplicationLetter).HasMaxLength(500);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsViewed).IsRequired();
 
            builder.HasIndex(x => new {  x.IsDeleted }).IsClustered(false).HasDatabaseName($"JobApplications_Mgr_NCIndex_{DateTime.Now:ddMMyyyy}");
            builder.HasIndex(x => new {  x.IsViewed }).IsClustered(false).HasDatabaseName($"JobApplications_Mgr_IsViewed_NCIndex_{DateTime.Now:ddMMyyyy}");
        }
    }
}
