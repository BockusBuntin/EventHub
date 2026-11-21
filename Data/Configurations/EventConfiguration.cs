using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.EventId);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(4000);

        builder.Property(e => e.MaxAttendees)
            .IsRequired();

        builder.HasOne(e => e.Organizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ParentEvent)
            .WithMany(e => e.Sessions)
            .HasForeignKey(e => e.ParentEventId)
            .OnDelete(DeleteBehavior.Restrict);

        // Internal platform timestamps: shadow properties, not visible in Event.
        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETDATE()");

        builder.Property<DateTime>("LastModifiedAt")
            .HasDefaultValueSql("GETDATE()");
    }
}
