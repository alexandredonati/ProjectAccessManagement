using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Infrastructure.Data.Configurations
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
                .IsRequired();

            builder.Property(c => c.ExpiryDate)
                .IsRequired();

            builder.Property(c => c.AllowsMultiAccess)
                .IsRequired();

            builder.HasOne(c => c.Application)
                .WithMany()
                .HasForeignKey("ApplicationId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(c => c.Modules)
                .WithMany()
                .UsingEntity(j => j.ToTable("CredentialModules"));
        }
    }
} 