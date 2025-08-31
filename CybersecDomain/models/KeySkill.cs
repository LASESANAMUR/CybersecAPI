using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CybersecDomain.models;


public class KeySkill
{
    [Key]
    public uint KeySkillId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Skill { get; set; }

    public uint ProfileId { get; set; }

    [ForeignKey("ProfileId")]
    public Profile Profile { get; set; }

    public DateTime CreatedAt { get; set; }
}