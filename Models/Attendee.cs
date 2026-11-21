using System.ComponentModel.DataAnnotations;

namespace EventHub.Models;

public class Attendee
{
    public int AttendeeId { get; set; }

    [Required, MaxLength(150)]
    public string FullName { get; set; }

    [Required, EmailAddress, MaxLength(254)]
    public string Email { get; set; }

    [Required, MaxLength(200)]
    public string Street { get; set; }

    [Required, MaxLength(100)]
    public string City { get; set; }

    [Required, MaxLength(100)]
    public string Country { get; set; }

    [Required, MaxLength(20)]
    public string PostalCode { get; set; }

    public Badge Badge { get; set; }

    public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
