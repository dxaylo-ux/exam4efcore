namespace Domain.Models;

public class Organizer
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public string? Phone { get; set; }

    public ICollection<Event> Events { get; set; } = new List<Event>();
}