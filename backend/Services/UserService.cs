using Apollo_hire.API.Data;
using Apollo_hire.API.DTOs;
using Apollo_hire.API.Models;
using Apollo_hire.API.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace Apollo_hire.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponseDto> SyncUserAsync(string auth0UserId, string email)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Auth0UserId == auth0UserId);
            if (existingUser != null)
            {
                return new UserResponseDto
                {
                    Id = existingUser.Id,
                    Name = existingUser.Username,
                    Email = existingUser.Email
                };
            }
            Random random = new Random();
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Auth0UserId = auth0UserId,
                Email = email,
                Username = "user" + Guid.NewGuid().ToString()[..8],
                CreatedAt = DateTime.UtcNow
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new UserResponseDto
            {
                Id = newUser.Id,
                Name = newUser.Username,
                Email = newUser.Email
            };
        }
        public async Task<User> GetUserByAuth0IdAsync(string auth0UserId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Auth0UserId == auth0UserId);
        }
    }
}
