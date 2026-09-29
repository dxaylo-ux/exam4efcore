using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Venue
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    public int Capacity { get; set; }

    public ICollection<Event> Events { get; set; }= new List<Event>();
}