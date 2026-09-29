namespace Application.DTOs.Ticket;

public class TicketDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int TicketTypeId { get; set; }
    public int AttendeeId { get; set; }
    public Guid Code { get; set; }
    public decimal Price { get; set; }
    public DateTime PurchasedAt { get; set; }
    public bool IsCheckedIn { get; set; }
    public DateTime? CheckedInAt { get; set; }
}