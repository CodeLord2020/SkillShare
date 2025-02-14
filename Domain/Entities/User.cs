using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Domain.Enums;

namespace SkillShare.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }    
        public UserRoles Roles { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdatedAt { get; set;}
        public bool IsVerified { get; set; }
        public int ReputationScore { get; set; }


        // Navigationa Properties.

        // public ICollection<SkillShare> Skills { get; set; } = new List<Skill>();
        // public ICollection<Trade> TradesAsInitiator { get; set; } = new List<Trade>();
        // public ICollection<Trade> TradesAsReceiver { get; set; } = new List<Trade>();
        // public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
    }
}