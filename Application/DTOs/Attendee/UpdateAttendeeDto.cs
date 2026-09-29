using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Attendee;

public class UpdateAttendeeDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime RegisteredAt { get; set; }
}