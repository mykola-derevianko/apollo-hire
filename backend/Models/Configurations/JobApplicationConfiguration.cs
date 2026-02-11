using Apollo_hire.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApolloHire.API.Models.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("job_applications");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.CompanyName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(j => j.JobTitle)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(j => j.Location)
                   .HasMaxLength(200);

            builder.Property(j => j.WorkType)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasConversion<string>();

            builder.Property(j => j.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasConversion<string>();

            builder.Property(j => j.Source)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(j => j.SourceUrl)
                   .IsRequired(false)
                   .HasColumnType("text");

            builder.Property(j => j.Notes)
                   .HasColumnType("text");

            builder.Property(j => j.IsArchived)
                    .IsRequired()
                    .HasDefaultValue(false);

            builder.Property(j => j.CreatedAt)
                   .HasDefaultValueSql("now() at time zone 'utc'");

            builder.Property(j => j.UpdatedAt)
                   .HasDefaultValueSql("now() at time zone 'utc'");

            builder.HasOne(j => j.User)
                   .WithMany(h => h.JobApplications)
                   .HasForeignKey(h => h.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
