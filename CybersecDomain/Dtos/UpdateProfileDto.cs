
namespace CybersecDomain.Dtos;

public class UpdateProfileDto
{
   
    public string Title { get; set; }
    
    public string ShortName { get; set; }
    
    public string LogoUrl { get; set; }
    
    public string Mission { get; set; }
    
    public string AlternativeTitle { get; set; } // list par virgules
    
    public string Deliverable { get; set; } // list par virgules
    
    public string Knowledge { get; set; } // list par virgules
    
    public string KeySkill { get; set; } // list par virgules
    
    public string MainTask { get; set; } // list par virgules
    
    public string SummaryStatement { get; set; } // list par virgules
}
