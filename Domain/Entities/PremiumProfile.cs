using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillShare.Domain.Entities
{
    public class PremiumProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public required User User { get; set; }

    }
}