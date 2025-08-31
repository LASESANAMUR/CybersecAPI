using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CybersecDomain.models;

public class Deliverable
{
    [Key]
    public uint DeliverableId { get; set; }

    [Required]
    [MaxLength(500)]
    public string DeliverableName { get; set; }

    public uint ProfileId { get; set; }

    [ForeignKey("ProfileId")]
    public Profile Profile { get; set; }

    public DateTime CreatedAt { get; set; }
}