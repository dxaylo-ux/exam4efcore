namespace Application.DTOs.Organizer;

public class OrganizerDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string ContactEmail { get; set; } = null!;
    public string? Phone { get; set; }
}