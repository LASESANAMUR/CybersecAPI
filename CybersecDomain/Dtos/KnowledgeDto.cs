namespace CybersecDomain.Dtos;

/// <summary>
/// Represents a Knowledge data transfer object.
/// </summary>
public class KnowledgeDto
{
    /// <summary>
    /// Gets or sets the name of the knowledge.
    /// </summary>
    public string KnowledgeName { get; set; }
    
    /// <summary>
    /// Gets or sets the date and time when the knowledge was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}