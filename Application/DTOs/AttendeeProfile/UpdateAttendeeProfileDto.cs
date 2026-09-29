using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.AttendeeProfiles;

public class UpdateAttendeeProfileDto
{
    public DateTime? DateOfBirth { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(1000)]
    public string? Bio { get; set; }
}