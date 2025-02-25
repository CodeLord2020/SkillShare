using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Configuration;
namespace SkillShare.Persistence.Data
{
    public class AppDbContext :IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {}
        
        // public DbSet<User> Users { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Reputation> Reputations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.OwnsOne(s => s.TimeSlot, ts =>
                {
                    ts.Property(t => t.StartTime).HasColumnName("StartTime");
                    ts.Property(t => t.EndTime).HasColumnName("EndTime");
                });
            });
            
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new TradeConfiguration());
            // modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new ReputationConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}