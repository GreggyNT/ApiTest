using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi.Entities;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public Guid Id { get; set; }
}