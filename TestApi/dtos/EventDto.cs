using System.ComponentModel.DataAnnotations;
using TestApi.Entities;

namespace TestApi.Dtos;

public class EventDto:BaseEntity
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
    [Required]
    public int? MaximumParticipants { get; set; }
    [Required]
    public string? Category { get; set; }
}