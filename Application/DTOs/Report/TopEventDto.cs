namespace Application.DTOs.Report;

public class TopEventDto
{
    public int EventId { get; set; }

    public string EventTitle { get; set; } = null!;

    public decimal Revenue { get; set; }
}