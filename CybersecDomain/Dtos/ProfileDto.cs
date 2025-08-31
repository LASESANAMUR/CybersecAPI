namespace CybersecDomain.Dtos;

public class ProfileDto
{
    public uint ProfileId { get; set; }
    public string Title { get; set; } = null!;
    public string Shortname { get; set; } = null!;
    public string? SummaryStatement { get; set; }
    public string? Mission { get; set; }
    public bool Status { get; set; }
    
    public LogoDto? Logo { get; set; }

    // Collections simplifiées : juste les listes de chaînes ou DTOs légers
    public List<string>? AlternativeTitles { get; set; }
    public List<KeySkillDto>? KeySkill { get; set; }
    public List<KnowledgeDto>? Knowledge { get; set; }
    public List<DeliverableDto>? Deliverables { get; set; }
    public List<MainTaskDto>? MainTasks { get; set; }
}