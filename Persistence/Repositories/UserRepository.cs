using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Data;

namespace SkillShare.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appdbContext)
        {
            _appDbContext = appdbContext ?? throw new ArgumentNullException(nameof(appdbContext));
        }

        public async Task AddUserAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user != null)
            {
                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await  _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user ?? throw new Exception($"User with email {email} not found.");
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);
            return user ?? throw new Exception($"User with refresh token {refreshToken} not found.");
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            return user ?? throw new Exception($"User with id: {id} not found.");

        }

        public async Task UpdateUserAsync(User user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}