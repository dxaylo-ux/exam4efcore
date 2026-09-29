namespace Domain.Models;

public class AttendeeProfile
{
    public int AttendeeId { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? City { get; set; }

    public string? Bio { get; set; }

    public Attendee Attendee { get; set; } = null!;
}