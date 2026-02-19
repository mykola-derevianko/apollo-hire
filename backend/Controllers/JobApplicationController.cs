using Apollo_hire.API.DTOs;
using Apollo_hire.API.Extensions;
using Apollo_hire.API.Models;
using Apollo_hire.API.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Apollo_hire.API.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly ILogger<JobApplicationController> _logger;

        public JobApplicationController(
            IJobApplicationService jobApplicationService,
            ILogger<JobApplicationController> logger)
        {
            _jobApplicationService = jobApplicationService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<JobApplicationResponseDto>> GetUserApplications(
            [FromQuery] JobApplicationQueryParameters queryParameters)
        {
            var auth0UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (auth0UserId == null) return Unauthorized();
            
            var result = await _jobApplicationService.GetUserApplicationsByAuth0IdAsync(auth0UserId, queryParameters);
                        
            return Ok(result);
        }
    }
}