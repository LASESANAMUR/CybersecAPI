using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CybersecDomain.models;

[Table("Main_task")]
public class MainTask
{
    [Key]
    public uint MainTaskId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Task { get; set; }
    

    [ForeignKey("ProfileId")]
    public Profile Profile { get; set; }
    
    public uint ProfileId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}