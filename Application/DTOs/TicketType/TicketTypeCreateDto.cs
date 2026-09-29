namespace Application.DTOs.TicketType;

public class TicketTypeCreateDto
{
    public int EventId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}