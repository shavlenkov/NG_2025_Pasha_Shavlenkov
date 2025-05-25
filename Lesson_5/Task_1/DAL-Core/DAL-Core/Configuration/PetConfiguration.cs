using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL_Core.Entities;

namespace DAL_Core.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Breed)
            .HasMaxLength(100);
        
        builder.HasOne(p => p.Store)
            .WithMany(s => s.Pets)
            .HasForeignKey(p => p.StoreId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasMany(p => p.HealthCares)
            .WithOne(h => h.Pet)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}