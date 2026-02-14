using System.Security.Claims;

namespace Apollo_hire.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static (string UserId, string Email)? GetAuth0User(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = user.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(email))
                return null;

            return (userId, email);
        }
    }
}
