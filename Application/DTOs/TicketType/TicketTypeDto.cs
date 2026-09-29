namespace Application.DTOs.TicketType;

public class TicketTypeDto
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int SoldCount { get; set; }
}