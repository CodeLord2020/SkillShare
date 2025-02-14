using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillShare.Domain.Entities;

namespace SkillShare.Persistence.Configuration
{
    public class ReputationConfiguration : IEntityTypeConfiguration<Reputation>
    {
        public void Configure(EntityTypeBuilder<Reputation> builder)
        {
            builder.HasKey(r => r.Id); // Primary Key

            builder.Property(r => r.Score).HasDefaultValue(0).IsRequired();

            builder.Property(r => r.CreatedAt).IsRequired();

            builder.Property(r => r.UpdatedAt)
                .IsRequired(false);

            // Foreign Key Relationship (One-to-One)
            builder.HasOne(r => r.User)
                .WithOne(u => u.Reputation) 
                .HasForeignKey<Reputation>(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade) // Delete Reputation if User is deleted
                .IsRequired();
        }
    }
}
