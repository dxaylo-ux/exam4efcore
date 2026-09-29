namespace Application.DTOs.Venue;

public class VenueUpdateDto
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public int Capacity { get; set; }
}