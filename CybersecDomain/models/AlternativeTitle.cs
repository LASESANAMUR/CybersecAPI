using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CybersecDomain.models;


[Table("Alternative_Title")]
public class AlternativeTitle
{
    [Key]
    public uint AlternativeTitleId { get; set; }

    [Required]
    [MaxLength(500)]
    public string AltTitle { get; set; }

    public uint ProfileId { get; set; }

    [ForeignKey("ProfileId")]
    public Profile Profile { get; set; }

    public DateTime CreatedAt { get; set; }
}