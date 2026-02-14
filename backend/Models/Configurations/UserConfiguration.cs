using Microsoft.EntityFrameworkCore;

namespace Apollo_hire.API.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Auth0UserId).IsRequired();
            builder.HasIndex(u => u.Auth0UserId).IsUnique();

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("now() at time zone 'utc'")
                   .IsRequired();
        }
    }
}
