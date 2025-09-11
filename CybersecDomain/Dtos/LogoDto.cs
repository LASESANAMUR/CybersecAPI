/// <summary>
/// Represents a DTO for a logo.
/// </summary>
/// <remarks>
/// This DTO is used to transfer data about a logo between the API and the client.
/// </remarks>
/// <property name="LogoId">The identifier of the logo.</property>
/// <property name="LogoUrl">The URL of the logo.</property>
namespace CybersecDomain.Dtos;

public class LogoDto
{
    /// <summary>
    /// The identifier of the logo.
    /// </summary>
    public uint LogoId { get; set; }
    
    /// <summary>
    /// The URL of the logo.
    /// </summary>
    public string LogoUrl { get; set; }
}