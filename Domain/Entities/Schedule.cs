using System;
using SkillShare.Domain.ValueObjects;

namespace SkillShare.Domain.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public TimeSlot? TimeSlot { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public required User User { get; set; }
    }
}