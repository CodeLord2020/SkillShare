using System;

namespace SkillShare.Domain.Entities
{
    public class Reputation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Score { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public User User { get; set; }
    }
}