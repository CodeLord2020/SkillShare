
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Domain.Enums;

namespace SkillShare.Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required SkillCategory Category { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public required User User { get; set; }
        public ICollection<Trade> Trades { get; set; } = new List<Trade>();

    }
}