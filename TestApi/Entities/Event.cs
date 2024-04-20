using System.ComponentModel.DataAnnotations;

namespace TestApi.Entities;

public class Event:BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string? Description { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string? Location { get; set; }
    
    [Required]
    public DateTime? DateTime  { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string? ImageUrl { get; set; }
    
    public int? MaximumParticipants { get; set; }
    
    public string? Category { get; set; }
    
    public virtual ICollection<EventParticipant> EventParticipants { get; set; }
}