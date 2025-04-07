using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Enums;

namespace ProjectAccessManagement.Repository.Configurations
{
    public class CredentialConfiguration : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CredentialType)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(c => c.ExpiryDate)
                .IsRequired();

            builder.Property(c => c.AllowsMultiAccess)
                .IsRequired();

            builder.HasOne(c => c.Application)
                .WithMany()
                .HasForeignKey("ApplicationId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(c => c.Modules)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "CredentialModules",
                    j => j.HasOne<Module>().WithMany().HasForeignKey("ModuleId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Credential>().WithMany().HasForeignKey("CredentialId").OnDelete(DeleteBehavior.NoAction)
                );
        }
    }
} 