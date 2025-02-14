using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillShare.Domain.Entities;

namespace SkillShare.Persistence.Configuration
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            
            builder.HasKey(s => s.Id);  // Primary Key

            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Description).HasMaxLength(500);
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired(false);

            builder.HasOne(s => s.User)  
                .WithMany(u => u.Skills) 
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade) // If User is deleted, delete their skills
                .IsRequired(); // Ensure every Skill is associated with a User

            // Indexes
            builder.HasIndex(s => s.Name);
        }
    }
}