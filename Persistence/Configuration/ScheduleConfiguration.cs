using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillShare.Domain.Entities;

namespace SkillShare.Persistence.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id); // Primary Key

            builder.Property(s => s.StartTime).IsRequired();
            builder.Property(s => s.EndTime).IsRequired();
            builder.Property(s => s.IsAvailable).HasDefaultValue(true);
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.UpdatedAt).IsRequired(false);


            // Relationship with User
            builder.HasOne(s => s.User)
                .WithMany(u => u.Schedules) 
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade) // If a user is deleted, their schedule is also removed
                .IsRequired();
        }
    }
}
