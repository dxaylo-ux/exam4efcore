using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Attendee;

public class AttendeeCreateDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
}