using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Data.Configurations;

public class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
{
    public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
    {
        builder.HasKey(p => p.OrganizerProfileId);

        builder.Property(p => p.Biography)
            .HasMaxLength(1000);

        builder.Property(p => p.WebsiteUrl)
            .HasMaxLength(300);

        builder.Property(p => p.LogoUrl)
            .HasMaxLength(500);

        builder.HasOne(p => p.Organizer)
            .WithOne(o => o.Profile)
            .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.OrganizerId)
            .IsUnique();
    }
}
