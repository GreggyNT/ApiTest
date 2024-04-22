using System.ComponentModel.DataAnnotations;

namespace TestApi.Entities;

public class Participant:BaseEntity
{

    public string? Name { get; set;}
   
    public string? Surname { get; set;}
    

    public string? Email { get; set;}
   
    public DateOnly RegistrationForEventDate { get; set; }
    
    public virtual ICollection<EventParticipant> EventParticipants { get; set; }
}