using System.ComponentModel.DataAnnotations;
using TestApi.Entities;

namespace TestApi.Dtos;

public class EventDto:BaseEntity
{

    public string? Name { get; set; }
    
    public string? Description { get; set; }
    

    public string? Location { get; set; }
    

    public DateTime? DateTime  { get; set; }
    

    public string? ImageUrl { get; set; }

    public int? MaximumParticipants { get; set; }
    public string? Category { get; set; }
}