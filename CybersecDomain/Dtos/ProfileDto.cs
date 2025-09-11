namespace CybersecDomain.Dtos;

/// <summary>
/// Data Transfer Object (DTO) representing a Cybersecurity Profile.
/// Contains all the necessary information to display a profile.
/// </summary>
public class ProfileDto
{
    /// <summary>
    /// Unique identifier of the profile.
    /// </summary>
    public uint ProfileId { get; set; }

    /// <summary>
    /// Title of the profile.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Short name of the profile.
    /// </summary>
    public string Shortname { get; set; } = null!;

    /// <summary>
    /// Summary statement of the profile.
    /// </summary>
    public string? SummaryStatement { get; set; }

    /// <summary>
    /// Mission statement of the profile.
    /// </summary>
    public string? Mission { get; set; }

    /// <summary>
    /// Status of the profile.
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// Logo of the profile.
    /// </summary>
    public LogoDto? Logo { get; set; }

    /// <summary>
    /// List of alternative titles for the profile.
    /// </summary>
    public List<string>? AlternativeTitles { get; set; }

    /// <summary>
    /// List of key skills for the profile.
    /// </summary>
    public List<KeySkillDto>? KeySkill { get; set; }

    /// <summary>
    /// List of knowledge for the profile.
    /// </summary>
    public List<KnowledgeDto>? Knowledge { get; set; }

    /// <summary>
    /// List of deliverables for the profile.
    /// </summary>
    public List<DeliverableDto>? Deliverables { get; set; }

    /// <summary>
    /// List of main tasks for the profile.
    /// </summary>
    public List<MainTaskDto>? MainTasks { get; set; }
}