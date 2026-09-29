using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth;

public class RegisterOrganizerDto
{
    [Required]
    [MaxLength(100)]
    public string CompanyName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string ContactEmail { get; set; } = null!;

    [MaxLength(30)]
    public string? Phone { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; } = null!;
}