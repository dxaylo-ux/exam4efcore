using Domain.Enums;

namespace Application.DTOs.Order;

public class OrderDto
{
    public int Id { get; set; }

    public int AttendeeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? PaidAt { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }
}