namespace Application.DTOs.Organizer;

public class OrganizerUpdateDto
{
    public string CompanyName { get; set; } = null!;
    public string ContactEmail { get; set; } = null!;
    public string? Phone { get; set; }
}