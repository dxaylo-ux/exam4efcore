namespace Domain.Models;

public class Ticket
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
    public Order Order { get; set; } = null!;
    public TicketType TicketType { get; set; } = null!;
    public Attendee Attendee { get; set; } = null!;
}