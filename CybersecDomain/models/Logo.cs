using System.ComponentModel.DataAnnotations;

namespace CybersecDomain.models;

public class Logo
{
    [Key]
    public uint LogoId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Url { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    // Navigation property
    public ICollection<Profile> Profiles { get; set; } = new List<Profile>();
}