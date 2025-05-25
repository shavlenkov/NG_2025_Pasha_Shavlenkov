using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL_Core.Entities;

namespace DAL_Core.Configuration;

public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(v => v.Description)
            .HasMaxLength(500);
        
        builder.HasMany(v => v.HealthCares)
            .WithOne(h => h.Vendor)
            .HasForeignKey(h => h.VendorId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}