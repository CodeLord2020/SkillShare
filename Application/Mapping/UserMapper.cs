using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Application.DTOs;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Enums;

namespace SkillShare.Application.Mapping
{
    public static class UserMapper
    {
        public static User ToEntity(this UserRegistrationDto dto)
        {
            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email, // Use email as username
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // Hash password
                Role = UserRoles.User, // Default role
                CreatedAt = DateTime.UtcNow,
                IsVerified = false, // Default to unverified
                ReputationScore = 0 // Default reputation score
            };
        }
    }

    public static UserResponseDto ToResponseDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email ?? " ",
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                LastUpdatedAt = user.LastUpdatedAt,
                IsVerified = user.IsVerified,
                ReputationScore = user.ReputationScore
            };
        }
}