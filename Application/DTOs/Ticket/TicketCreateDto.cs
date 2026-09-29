namespace Application.DTOs.Ticket;

public class TicketCreateDto
{
    public int OrderId { get; set; }
    public int TicketTypeId { get; set; }
    public int AttendeeId { get; set; }
    public decimal Price { get; set; }
}