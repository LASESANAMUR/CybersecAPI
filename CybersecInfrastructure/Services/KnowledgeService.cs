using CybersecDomain.context;
using CybersecDomain.models;
using CybersecInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CybersecInfrastructure.Services;

public class KnowledgeService: IKnowledgeService
{
    private readonly CyberSecDbContext _dbContext;
    
    public KnowledgeService(CyberSecDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ServiceResult<List<Knowledge>>> CreateKnowledge(List<string> knowledgeName, uint profileId)
    {
        try
        {
            List<Knowledge> knowledges = new List<Knowledge>();
        
            if(knowledgeName.Count == 0)
                return ServiceResult<List<Knowledge>>.Failure("Aucune connaissance fournie.");

            foreach (var knowledge in knowledgeName)
            {
                knowledges.Add(new Knowledge
                {
                    ProfileId = profileId,
                    KnowledgeName = knowledge.Trim(),
                    CreatedAt = DateTime.UtcNow
                });
            }
       
            await _dbContext.Knowledge.AddRangeAsync(knowledges);
            await _dbContext.SaveChangesAsync();
       
            return ServiceResult<List<Knowledge>>.Success(knowledges);
        }
        catch(DbUpdateException ex)
        {
            // Erreur spécifique à la base de données
            return ServiceResult<List<Knowledge>>.Failure($"Erreur lors de l'enregistrement en base : {ex.Message}");
        }
        catch (Exception ex)
        {
            return ServiceResult<List<Knowledge>>.Failure($"Erreur inattendue : {ex.Message}");
        }
    }
}