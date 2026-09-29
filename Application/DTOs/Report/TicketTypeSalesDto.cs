namespace Application.DTOs.Report;

public class TicketTypeSalesDto
{
    public int TicketTypeId { get; set; }
    public string TicketTypeName { get; set; } = null!;
    public int SoldCount { get; set; }
    public decimal Revenue { get; set; }
    public double OccupancyPercentage { get; set; }
    public double CheckInPercentage { get; set; }
}