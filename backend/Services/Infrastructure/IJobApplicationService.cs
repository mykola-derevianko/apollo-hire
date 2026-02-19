using Apollo_hire.API.DTOs;
using Apollo_hire.API.Models;

namespace Apollo_hire.API.Services.Infrastructure
{
    public interface IJobApplicationService
    {
        Task<PagedResponseDto<JobApplicationResponseDto>> GetUserApplicationsByAuth0IdAsync(
            string auth0UserId, 
            JobApplicationQueryParameters queryParameters
        );


    }
}
