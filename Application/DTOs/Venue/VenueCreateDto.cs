namespace Application.DTOs.Venue;

public class VenueCreateDto
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public int Capacity { get; set; }
}