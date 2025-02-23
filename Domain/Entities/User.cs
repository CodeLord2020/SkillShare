using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SkillShare.Domain.Enums;

namespace SkillShare.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }  
        public UserRoles Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdatedAt { get; set;}
        public bool IsVerified { get; set; }
        public int ReputationScore { get; set; } = 0;


        // Navigationa Properties.
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<Trade> TradesAsInitiator { get; set; } = new List<Trade>();
        public ICollection<Trade> TradesAsReceiver { get; set; } = new List<Trade>();   
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public Reputation? Reputation { get; set; }

    }
}