using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;

namespace SkillShare.Domain.Events
{
    public class ReputationUpdatedEvent
    {
        public User User { get; }

        public ReputationUpdatedEvent(User user)
        {
            User = user;
            
        }
    }
}