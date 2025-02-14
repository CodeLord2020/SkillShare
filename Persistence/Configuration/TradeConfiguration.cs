using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillShare.Domain.Entities;

namespace SkillShare.Persistence.Configuration
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.HasKey(t => t.Id); // Primary Key

            builder.Property(t => t.HoursOffered).IsRequired();
            builder.Property(t => t.HoursRequested).IsRequired();
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.UpdatedAt).IsRequired(false);

            // Trade -> Initiator (User)
            builder.HasOne(t => t.Initiator)
                .WithMany(u => u.TradesAsInitiator)
                .HasForeignKey(t => t.InitiatorId)
                .OnDelete(DeleteBehavior.Restrict) // Prevents cascading delete to keep d trade history
                .IsRequired();

            // Trade -> Receiver (User)
            builder.HasOne(t => t.Receiver)
                .WithMany(u => u.TradesAsReceiver)
                .HasForeignKey(t => t.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Trade -> SkillOffered (Skill)
            builder.HasOne(t => t.SkillOffered)
                .WithMany()
                .HasForeignKey(t => t.SkillOfferedId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Trade -> SkillRequested (Skill)
            builder.HasOne(t => t.SkillRequested)
                .WithMany()
                .HasForeignKey(t => t.SkillRequestedId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
