using Domain.Enums;

namespace Application.DTOs.Event;

public class EventDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public string City { get; set; } = null!;

    public EventStatus Status { get; set; }

    public decimal MinPrice { get; set; }
}