using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Configurations;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasKey(v => v.Id);
        
        builder.HasOne(v => v.User)
            .WithMany(u => u.Votes)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        builder.HasOne(v => v.Project)
            .WithMany(p => p.Votes)
            .HasForeignKey(v => v.ProjectId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}