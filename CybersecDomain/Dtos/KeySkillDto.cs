/// <summary>
/// Represents a DTO for key skill.
/// </summary>
/// <property name="KeySkillId">The identifier of the key skill.</property>
/// <property name="Skill">The skill.</property>
/// <property name="CreatedAt">The date and time when the key skill was created.</property>
public class KeySkillDto
{
    /// <summary>
    /// The identifier of the key skill.
    /// </summary>
    public uint KeySkillId { get; set; }
    
    /// <summary>
    /// The skill.
    /// </summary>
    public string Skill { get; set; }
    
    /// <summary>
    /// The date and time when the key skill was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}