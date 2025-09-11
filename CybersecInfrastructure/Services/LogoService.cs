using CybersecDomain.context;
using CybersecDomain.models;
using CybersecInfrastructure.Interfaces;
using CybersecInfrastructure.Interfaces;
using CybersecInfrastructure.Services;

namespace CybersecInfrastructure.Services;

public class LogoService : ILogoService
{
    private readonly CyberSecDbContext _dbContext;

    public LogoService(CyberSecDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Creates a new logo and saves it in the database.
    /// </summary>
    /// <param name="url">The URL of the logo.</param>
    /// <returns>A <see cref="ServiceResult{Logo}"/> containing the created logo or an error message.</returns>
    public async Task<ServiceResult<Logo>> CreateLogoAsync(string url)
    {
        try
        {
            var logo = new Logo
            {
                Url = url,
                CreatedAt = DateTime.UtcNow
            };
            
            _dbContext.Logos.Add(logo);
            await _dbContext.SaveChangesAsync();
            return ServiceResult<Logo>.Success(logo);
        }
        catch (Exception ex)
        {
            return ServiceResult<Logo>.Failure($"An error occurred: {ex.Message}");
        }
    }
}