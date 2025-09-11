/// <summary>
/// Represents a DTO for main task.
/// Contains the basic information of a main task.
/// </summary>
public class MainTaskDto
{
    /// <summary>
    /// The identifier of the main task.
    /// </summary>
    public uint MainTaskId { get; set; }
    
    /// <summary>
    /// The description of the main task.
    /// </summary>
    public string Task { get; set; }
    
    /// <summary>
    /// The date and time when the main task was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// The date and time when the main task was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}