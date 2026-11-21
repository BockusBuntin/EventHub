namespace EventHub.Models;

public class Registration
{
    public int RegistrationId { get; set; }

    public int AttendeeId { get; set; }
    public int EventId { get; set; }

    public string Note { get; set; }
    public DateTime RegisteredAt { get; set; }

    public Attendee Attendee { get; set; }
    public Event Event { get; set; }
}
