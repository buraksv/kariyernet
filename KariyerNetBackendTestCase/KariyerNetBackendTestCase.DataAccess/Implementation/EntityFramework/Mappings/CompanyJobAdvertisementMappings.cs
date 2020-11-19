using System;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Mappings
{
    public class CompanyJobAdvertisementMappings : IEntityTypeConfiguration<CompanyJobAdvertisement>
    {
        public void Configure(EntityTypeBuilder<CompanyJobAdvertisement> builder)
        {
            builder.ToTable("CompanyJobAdvertisements");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CompanyId);

            builder.Property(x => x.Description).HasMaxLength(1500).IsRequired();
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.CityId).IsRequired();
            builder.Property(x => x.TownId).IsRequired();
            builder.Property(x => x.ExpirationTime).IsRequired(); 
            builder.Property(x => x.CreatedTime).HasDefaultValue(DateTimeOffset.Now);

            builder.HasIndex(x => new { x.CompanyId  }).IsClustered(false).HasDatabaseName($"CompanyJobAdvertisement_CompanyId_Mgr_NCIndex_{DateTime.Now:ddMMyyyy}");
        }
    }
}
