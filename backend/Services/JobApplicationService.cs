using Apollo_hire.API.Data;
using Apollo_hire.API.DTOs;
using Apollo_hire.API.Models;
using Apollo_hire.API.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Apollo_hire.API.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly AppDbContext _context;
        public JobApplicationService(AppDbContext context) {
            _context = context;
        }

        public async Task<ICollection<JobApplicationResponseDto>> GetUserAplicationsAsync(Guid userId)
        {
            return await _context.JobApplications
                .Where(a => a.UserId == userId)
                .Select(a => new JobApplicationResponseDto
                {
                    Id = a.Id,
                    UserId = a.UserId,
                    CompanyName = a.CompanyName,
                    JobTitle = a.JobTitle,
                    Location = a.Location,
                    WorkType = a.WorkType,
                    Status = a.Status,
                    Source = a.Source,
                    SourceUrl = a.SourceUrl,
                    AppliedDate = a.AppliedDate,
                    Notes = a.Notes,
                    IsArchived = a.IsArchived,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt,
                    EventCount = a.Events.Count
                })
                .ToListAsync();
        }
    }
}
