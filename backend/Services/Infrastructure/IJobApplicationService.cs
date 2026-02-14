using Apollo_hire.API.DTOs;
using Apollo_hire.API.Models;

namespace Apollo_hire.API.Services.Infrastructure
{
    public interface IJobApplicationService
    {
        Task<ICollection<JobApplicationResponseDto>> GetUserAplicationsAsync(Guid userId);
    }
}
