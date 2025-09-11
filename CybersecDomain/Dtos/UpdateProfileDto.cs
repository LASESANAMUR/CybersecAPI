namespace CybersecDomain.Dtos;

/// <summary>
/// Data Transfer Object for updating an existing profile.
/// Contains all the necessary information to update a cybersecurity profile.
/// </summary>
public class UpdateProfileDto
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
    /// Gets or sets the URL of the profile logo. Can be null if no logo is provided.
    /// </summary>
    public string? LogoUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the mission statement of the profile.
    /// </summary>
    public string Mission { get; set; }
    
    /// <summary>
    /// Gets or sets the alternative titles as a comma-separated list.
    /// </summary>
    public string AlternativeTitle { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the deliverables as a comma-separated list.
    /// </summary>
    public string Deliverable { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the knowledge areas as a comma-separated list.
    /// </summary>
    public string Knowledge { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the key skills as a comma-separated list.
    /// </summary>
    public string KeySkill { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the main tasks as a comma-separated list.
    /// </summary>
    public string MainTask { get; set; } // list par virgules
    
    /// <summary>
    /// Gets or sets the summary statements as a comma-separated list.
    /// </summary>
    public string SummaryStatement { get; set; } // list par virgules
}