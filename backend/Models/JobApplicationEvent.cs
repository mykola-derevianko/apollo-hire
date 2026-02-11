using Apollo_hire.API.Models.Enums;

namespace Apollo_hire.API.Models
{
    public class JobApplicationEvent
    {
        public Guid Id { get; set; }

        public Guid JobApplicationId { get; set; }

        public ApplicationEventType EventType { get; set; }

        public ApplicationStatus? OldStatus { get; set; }
        public ApplicationStatus? NewStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public JobApplication JobApplication { get; set; } = null!;

    }

}
