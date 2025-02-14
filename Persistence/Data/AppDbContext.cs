using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Configuration;
namespace SkillShare.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {}
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}