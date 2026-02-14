using Apollo_hire.API.DTOs;
using Apollo_hire.API.Extensions;
using Apollo_hire.API.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Apollo_hire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("sync")]
        [Authorize]
        public async Task<ActionResult<UserResponseDto>> SyncUser()
        {
            var auth0User = User.GetAuth0User();
            if (auth0User == null) return Unauthorized();
            var user = await _userService.SyncUserAsync(auth0User.Value.UserId, auth0User.Value.Email);
            return Ok(user);
        }
    }
}
