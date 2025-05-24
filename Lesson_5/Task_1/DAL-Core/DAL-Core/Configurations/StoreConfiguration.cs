using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL_Core.Entities;

namespace DAL_Core.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(s => s.Address)
            .HasMaxLength(300);
        builder.Property(s => s.City)
            .HasMaxLength(100);
    }
}