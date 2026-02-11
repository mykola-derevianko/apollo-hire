using Apollo_hire.API.Models.Enums;

namespace Apollo_hire.API.Models
{
    public class JobApplication
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

        public bool IsArchived { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;
        public ICollection<JobApplicationEvent> Events { get; set; } = new List<JobApplicationEvent>();
    }
}
