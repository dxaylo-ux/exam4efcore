using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.AttendeeProfiles;
public class AttendeeProfileDto
{
    public int AttendeeId { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? City { get; set; }
    public string? Bio { get; set; }
}