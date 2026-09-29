using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Models;

public class Event
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(2000)]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public EventStatus Status { get; set; }

    public int VenueId { get; set; }

    public int OrganizerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Venue Venue { get; set; } = null!;

    public Organizer Organizer { get; set; } = null!;

    public ICollection<Category> Categories { get; set; }= new List<Category>();

    public ICollection<TicketType> TicketTypes { get; set; }= new List<TicketType>();

    public ICollection<Review> Reviews { get; set; }= new List<Review>();
}