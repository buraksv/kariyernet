using System;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Mappings
{
    public class CompanyMappings : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.CompanyName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CompanyAddress).HasMaxLength(500).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
 
            builder.HasIndex(x => new { x.IsActive, x.IsDeleted }).IsClustered(false).HasDatabaseName($"Companies_Mgr_NCIndex_{DateTime.Now:ddMMyyyy}");
        }
    }
}
