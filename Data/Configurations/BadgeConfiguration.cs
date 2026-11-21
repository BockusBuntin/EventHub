using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Data.Configurations;

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.HasKey(b => b.BadgeId);

        builder.Property(b => b.CredentialNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.IssuedDate)
            .IsRequired();

        builder.Property(b => b.Tier)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(b => b.Attendee)
            .WithOne(a => a.Badge)
            .HasForeignKey<Badge>(b => b.AttendeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(b => b.CredentialNumber)
            .IsUnique();

        builder.HasIndex(b => b.AttendeeId)
            .IsUnique();
    }
}
