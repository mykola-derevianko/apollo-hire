using Apollo_hire.API.DTOs;
using Apollo_hire.API.Models;

namespace Apollo_hire.API.Services.Infrastructure
{
    public interface IUserService
    {
        Task<UserResponseDto> SyncUserAsync(string auth0UserId, string email);
        Task<User> GetUserByAuth0IdAsync(string auth0UserId);
    }
}
