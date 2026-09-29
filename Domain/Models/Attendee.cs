namespace Domain.Models;

public class Attendee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime RegisteredAt { get; set; }

    public AttendeeProfile? Profile { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}