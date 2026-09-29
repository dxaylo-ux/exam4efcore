using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Event;

public class EventCreateDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int VenueId { get; set; }
    public List<int> CategoryIds { get; set; } = new();
}