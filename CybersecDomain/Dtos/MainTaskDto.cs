namespace CybersecDomain.Dtos;

public class MainTaskDto
{
    public uint MainTaskId;

    public string Task { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}