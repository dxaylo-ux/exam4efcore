namespace Application.DTOs.Organizer;

public class OrganizerCreateDto
{
    public string CompanyName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public string? Phone { get; set; }
}