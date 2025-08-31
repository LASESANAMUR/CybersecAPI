using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CybersecDomain.models;

public class Profile
{
    [Key]
    [Column("profile_id")]
    public uint ProfileId { get; set; }

    [Required]
    [MaxLength(500)]
    [Column("title")]
    public string Title { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("shortname")]
    public string Shortname { get; set; }
    public string? SummaryStatement { get; set; }

    public string? Mission { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool Status { get; set; } = true;

    [ForeignKey("Logo")]
    public uint? LogoId { get; set; }

    public Logo? Logo { get; set; }

    // Navigation properties
    public ICollection<AlternativeTitle> AlternativeTitles { get; set; } = new List<AlternativeTitle>();
    public ICollection<KeySkill> KeySkill { get; set; } = new List<KeySkill>();
    public ICollection<Knowledge> Knowledge { get; set; } = new List<Knowledge>();
    public ICollection<Deliverable> Deliverables { get; set; } = new List<Deliverable>();
    public ICollection<MainTask> MainTasks { get; set; } = new List<MainTask>();
}