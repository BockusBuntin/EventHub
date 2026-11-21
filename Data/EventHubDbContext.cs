using EventHub.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Data;

public class EventHubDbContext : DbContext
{
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<Registration> Registrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\MSSQLLocalDB;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Separate configuration classes: no entity is configured here directly.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventHubDbContext).Assembly);
    }
}
