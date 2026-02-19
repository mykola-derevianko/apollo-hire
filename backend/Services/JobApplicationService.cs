using Apollo_hire.API.Data;
using Apollo_hire.API.DTOs;
using Apollo_hire.API.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Apollo_hire.API.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly AppDbContext _context;
        public JobApplicationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponseDto<JobApplicationResponseDto>> GetUserApplicationsByAuth0IdAsync(string auth0UserId, JobApplicationQueryParameters queryParameters)
        {
            var query = _context.JobApplications
                        .AsNoTracking()
                        .Where(a => a.User.Auth0UserId == auth0UserId);

            if (queryParameters.Search is not null)
            {
                query = query
                    .Where(a => a.JobTitle.ToLower().Contains(queryParameters.Search.ToLower()));
            }

            var totalCount = await query.CountAsync();

            var applications = await query
                .OrderBy($"{queryParameters.SortColumn} {queryParameters.SortDirection}")
                .Skip(queryParameters.PageIndex * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
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
                    EventCount = _context.JobApplicationEvents.Count(e => e.JobApplicationId == a.Id)
                }).ToListAsync();

            return new PagedResponseDto<JobApplicationResponseDto>(
                applications,
                totalCount,
                queryParameters.PageIndex,
                queryParameters.PageSize
            );

        }
    }
}
