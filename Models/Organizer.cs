using System.ComponentModel.DataAnnotations;

namespace EventHub.Models;

public class Organizer
{
    public int OrganizerId { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; }

    [MaxLength(150)]
    public string CompanyName { get; set; }

    public bool IsVerified { get; set; }

    public OrganizerProfile Profile { get; set; }

    public ICollection<Event> Events { get; set; } = new List<Event>();
}
