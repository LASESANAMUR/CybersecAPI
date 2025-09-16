namespace CybersecDomain.Dtos;

/// <summary>
/// Data Transfer Object for creating a new profile.
/// Contains all the necessary information to create a cybersecurity profile.
/// </summary>
public class CreateProfileDto
{
    /// <summary>
    /// Gets or sets the title of the profile.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Gets or sets the short name of the profile.
    /// </summary>
    public string ShortName { get; set; }
    
    /// <summary>
    /// Gets or sets the logo URL for the profile.
    /// </summary>
    public string? LogoUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the mission statement of the profile.
    /// </summary>
    public string Mission { get; set; }
    
    /// <summary>
    /// Gets or sets the alternative titles for the profile.
    /// </summary>
    public string? AlternativeTitle { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the deliverables associated with the profile.
    /// </summary>
    public string? Deliverable { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the knowledge areas for the profile.
    /// </summary>
    public string Knowledge { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the key skills for the profile.
    /// </summary>
    public string KeySkill { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the main tasks for the profile.
    /// </summary>
    public string? MainTask { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the summary statements for the profile.
    /// </summary>
    public string SummaryStatement { get; set; } // list par virgules
}