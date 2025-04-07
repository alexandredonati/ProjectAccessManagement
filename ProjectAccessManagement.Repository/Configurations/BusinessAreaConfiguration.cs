using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Repository.Configurations
{
    public class BusinessAreaConfiguration : IEntityTypeConfiguration<BusinessArea>
    {
        public void Configure(EntityTypeBuilder<BusinessArea> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.Automations)
                .WithOne(a => a.BusinessArea)
                .HasForeignKey("BusinessAreaId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
} 