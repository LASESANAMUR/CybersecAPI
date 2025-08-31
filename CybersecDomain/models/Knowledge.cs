using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CybersecDomain.models;

[Table("Knowledge")]
public class Knowledge
{
    [Key]
    public uint KnowledgeId { get; set; }

    [Required]
    [MaxLength(500)]
    public string KnowledgeName { get; set; }

    public uint ProfileId { get; set; }

    [ForeignKey("ProfileId")]
    public Profile Profile { get; set; }

    public DateTime CreatedAt { get; set; }
}