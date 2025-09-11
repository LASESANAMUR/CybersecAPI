using CybersecDomain.context;
using CybersecDomain.models;
using CybersecInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CybersecInfrastructure.Services;

public class keySkillService : IKeySkillService
{
    private readonly CyberSecDbContext _dbContext;

    public keySkillService(CyberSecDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Creates new key skills for the given profile ID.
    /// </summary>
    /// <param name="skills">The list of skills to add.</param>
    /// <param name="profileId">The ID of the profile to add the skills for.</param>
    /// <returns>A service result containing the list of created key skills.</returns>
    /// <summary>
    
    public async Task<ServiceResult<List<KeySkill>>> CreateKeySkills(List<string> skills, uint profileId)
    {
        try
        {
            var keySkills = new List<KeySkill>();

            foreach (var skill in skills)
            {
                keySkills.Add(new KeySkill
                {
                    
                    ProfileId = profileId,
                    Skill = skill.Trim(),
                    CreatedAt = DateTime.UtcNow
                });
            }
            
            await _dbContext.KeySkills.AddRangeAsync(keySkills);
            await _dbContext.SaveChangesAsync();
            
            return ServiceResult<List<KeySkill>>.Success(keySkills);
        }
        catch (DbUpdateException ex)
        {
            // Erreur spécifique à la base de données
            return ServiceResult<List<KeySkill>>.Failure($"Erreur lors de l'enregistrement en base : {ex.Message}");
        }
        catch (Exception ex)
        {
            // Erreur inattendue
            return ServiceResult<List<KeySkill>>.Failure($"Erreur inattendue : {ex.Message}");
        }
    }
}