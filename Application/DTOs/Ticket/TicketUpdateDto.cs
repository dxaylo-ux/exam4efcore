namespace Application.DTOs.Ticket;

public class TicketUpdateDto
{
    public int OrderId { get; set; }
    public int TicketTypeId { get; set; }
    public int AttendeeId { get; set; }
    public decimal Price { get; set; }
    public bool IsCheckedIn { get; set; }
    public DateTime? CheckedInAt { get; set; }
}