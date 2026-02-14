using Apollo_hire.API.Models.Enums;

namespace Apollo_hire.API.DTOs
{
    public class JobApplicationResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        
        public string CompanyName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string Location { get; set; } = null!;
        public WorkType WorkType { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Source { get; set; } = null!;
        public string? SourceUrl { get; set; }
        public DateTime? AppliedDate { get; set; }
        public string? Notes { get; set; }
        
        public bool IsArchived { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public int EventCount { get; set; }
    }
}