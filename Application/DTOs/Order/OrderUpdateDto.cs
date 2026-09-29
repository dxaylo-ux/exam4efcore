using Domain.Enums;

namespace Application.DTOs.Order;

public class OrderUpdateDto
{
    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime? PaidAt { get; set; }
}