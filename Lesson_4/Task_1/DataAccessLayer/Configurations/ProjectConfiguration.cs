using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(p => p.CreationDate)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(p => p.Creator)
            .WithMany(u => u.Projects)
            .HasForeignKey(p => p.CreatorId);
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.CategoryId);
    }
}