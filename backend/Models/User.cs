namespace Apollo_hire.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Auth0UserId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
