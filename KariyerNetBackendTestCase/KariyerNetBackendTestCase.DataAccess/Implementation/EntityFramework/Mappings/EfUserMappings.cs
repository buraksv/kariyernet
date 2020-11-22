using System;
using KariyerNetBackendTestCase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Mappings
{
    public class EfUserMappings : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(25).IsRequired();
            builder.Property(x => x.UserCvId);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
 
            builder.HasIndex(x => new {  x.IsActive,x.IsDeleted }).IsClustered(false).HasDatabaseName($"Users_Mgr_NCIndex_{DateTime.Now:ddMMyyyy}");
        }
    }
}
