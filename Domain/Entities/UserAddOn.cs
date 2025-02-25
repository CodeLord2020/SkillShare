using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillShare.Domain.Entities
{
    public class UserAddOn
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AddOnId { get; set; }
        public DateTime PurchaseDate { get; set; }

        // Navigation properties
        public required User User { get; set; }
        public required AddOn AddOn { get; set; }
    }
}