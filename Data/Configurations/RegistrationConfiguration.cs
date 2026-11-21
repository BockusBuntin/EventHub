using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Data.Configurations;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.HasKey(r => r.RegistrationId);

        builder.Property(r => r.Note)
            .HasMaxLength(1000);

        builder.Property(r => r.RegisteredAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(r => r.Attendee)
            .WithMany(a => a.Registrations)
            .HasForeignKey(r => r.AttendeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Event)
            .WithMany(e => e.Registrations)
            .HasForeignKey(r => r.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => new { r.AttendeeId, r.EventId })
            .IsUnique();
    }
}
