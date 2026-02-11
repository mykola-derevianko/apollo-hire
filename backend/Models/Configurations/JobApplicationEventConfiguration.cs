using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apollo_hire.API.Models.Configurations
{
    public class JobApplicationEventConfiguration : IEntityTypeConfiguration<JobApplicationEvent>
    {
        public void Configure(EntityTypeBuilder<JobApplicationEvent> builder)
        {
            builder.ToTable("job_application_events");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.EventType)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(e => e.OldStatus)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(e => e.NewStatus)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(e => e.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("now() at time zone 'utc'");

            builder.HasOne(e => e.JobApplication)
                   .WithMany(j => j.Events)
                   .HasForeignKey(e => e.JobApplicationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => new { e.JobApplicationId, e.CreatedAt });
        }
    }
}
