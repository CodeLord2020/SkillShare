using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillShare.Application.DTOs
{
    public class RefreshTokenRequest
    {
      public required string RefreshToken { get; set; }
    }
}