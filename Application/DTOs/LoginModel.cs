using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillShare.Application.DTOs
{
    public class LoginModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}