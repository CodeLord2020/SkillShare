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
        public DbSet<PremiumProfile> PremiumProfiles { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<UserAddOn> UserAddOns { get; set; }

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

            modelBuilder.Entity<PremiumProfile>(entity =>
            {
                entity.HasOne(p => p.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<AddOn>()
                .Property(a => a.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<UserAddOn>(entity =>
            {
                entity.HasOne(ua => ua.User)
                    .WithMany()
                    .HasForeignKey(ua => ua.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ua => ua.AddOn)
                    .WithMany()
                    .HasForeignKey(ua => ua.AddOnId)
                    .OnDelete(DeleteBehavior.Cascade);
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