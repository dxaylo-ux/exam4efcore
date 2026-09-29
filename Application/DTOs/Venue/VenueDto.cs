namespace Application.DTOs.Venue;

public class VenueDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public int Capacity { get; set; }
}