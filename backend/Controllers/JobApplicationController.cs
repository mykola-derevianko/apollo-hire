using Apollo_hire.API.DTOs;
using Apollo_hire.API.Extensions;
using Apollo_hire.API.Models;
using Apollo_hire.API.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apollo_hire.API.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJobApplicationService _jobApplicationService;
        public JobApplicationController(IUserService userService, IJobApplicationService jobApplicationService)
        {
            _userService = userService;
            _jobApplicationService = jobApplicationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<JobApplicationResponseDto>> GetUserApplications()
        {
            var auth0User = User.GetAuth0User();
            if (auth0User == null) return Unauthorized();
            var user = await _userService.GetUserByAuth0IdAsync(auth0User.Value.UserId);
            if (user == null) return Unauthorized();
            return await _jobApplicationService.GetUserAplicationsAsync(user.Id) is var applications
                ? Ok(applications)
                : NotFound();

        }
    }
}
