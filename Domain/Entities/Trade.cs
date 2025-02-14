using System;
using SkillShare.Domain.Enums;

namespace SkillShare.Domain.Entities
{
    public class Trade
    {
        public Guid Id { get; set; }
        public Guid InitiatorId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid SkillOfferedId { get; set; }
        public Guid SkillRequestedId { get; set; }
        public int HoursOffered { get; set; }
        public int HoursRequested { get; set; }
        public TradeStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public required User Initiator { get; set; }
        public required User Receiver { get; set; }
        public required Skill SkillOffered { get; set; }
        public required Skill SkillRequested { get; set; }
    }
}