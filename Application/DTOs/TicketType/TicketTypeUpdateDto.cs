namespace Application.DTOs.TicketType;

public class TicketTypeUpdateDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}