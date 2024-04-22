using System.ComponentModel.DataAnnotations;

namespace TestApi.Dtos;

public class ParticipantDto
{
    public string? Name { get; set;}
    
    public string? Surname { get; set;}
    
    public string? Email { get; set;}
    
    public DateOnly RegistrationForEventDate { get; set; }
}