/// <summary>
/// Represents a DTO for deliverable.
/// </summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "DTO properties")]
public class DeliverableDto
{
    /// <summary>
    /// The name of the deliverable.
    /// </summary>
    public string DeliverableName { get; set; }

    /// <summary>
    /// The date and time when the deliverable was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}