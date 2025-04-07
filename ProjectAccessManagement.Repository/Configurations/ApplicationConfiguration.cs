using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Enums;

namespace ProjectAccessManagement.Repository.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.AppType)
                .IsRequired()
                .HasConversion<string>();

            builder.HasMany(a => a.Modules)
                .WithOne(m => m.Application)
                .HasForeignKey("ApplicationId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
} 