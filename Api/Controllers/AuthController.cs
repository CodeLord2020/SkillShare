using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SkillShare.Application.DTOs;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Enums;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SkillShare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(UserManager<User> userManager, IUserService userService, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _userService = userService; 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
                
            };
            if (model.Role != null && Enum.TryParse<UserRoles>(model.Role, out var role))
            {
                user.Role = role;
            }
            else
            {
                user.Role = UserRoles.User;
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User created successfully" });
            }
            else
            {
                return BadRequest(new { Message = "User creation failed", Errors = result.Errors });
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var accessToken = GenerateJwtToken(user);
                var refreshToken = GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiry = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration.GetSection("Jwt")["RefreshTokenExpiryInMinutes"]));
                await _userManager.UpdateAsync(user);

                return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken, 
                    User = new { user.Id, user.FirstName, user.LastName, user.Email, user.Role } });
            }

            return Unauthorized();
        }


        [HttpPost("accesstoken")]
        public async Task<IActionResult> RefreshAccessToken([FromBody] RefreshTokenRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return BadRequest(new { Message = "Invalid refresh token." });
            }

            var user = await _userService.GetUserByRefreshTokenAsync(request.RefreshToken);
            if (user == null)
            {
                return BadRequest(new { Message = "Invalid refresh token." });
            }

            if (user.RefreshTokenExpiry < DateTime.UtcNow)
            {
                return BadRequest(new { Message = "Refresh token has expired." });
            }

            var accessToken = GenerateJwtToken(user);
            return Ok(new { AccessToken = accessToken });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var keyString = jwtSettings["Key"] ??
                throw new InvalidOperationException("JWT Key is not configured properly.");
            
            var key = Encoding.ASCII.GetBytes(keyString);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                        Issuer = jwtSettings["Issuer"], Audience = jwtSettings["Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

    }
}