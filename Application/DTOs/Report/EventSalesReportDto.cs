namespace Application.DTOs.Report;

public class EventSalesReportDto
{
    public int EventId { get; set; }
    public string EventTitle { get; set; } = null!;
    public List<TicketTypeSalesDto> TicketTypes { get; set; } = new();
}