using System.ComponentModel.DataAnnotations;

namespace TestApi.Dtos;

public class ParticipantDto
{
    public string? Name { get; set;}
    
    [Required]
    [MaxLength(255)]
    public string? Surname { get; set;}
    
    [Required]
    [MaxLength(255)]
    public string? Email { get; set;}
    
    [Required]
    public DateOnly RegistrationForEventDate { get; set; }
}