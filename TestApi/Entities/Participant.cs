using System.ComponentModel.DataAnnotations;

namespace TestApi.Entities;

public class Participant:BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string? Name { get; set;}
    
    [Required]
    [MaxLength(255)]
    public string? Surname { get; set;}
    
    [Required]
    [MaxLength(255)]
    public string? Email { get; set;}
    
    [Required]
    public DateOnly RegistrationForEventDate { get; set; }
    
    public virtual ICollection<EventParticipant> EventParticipants { get; set; }
}