using CybersecDomain.context;
using CybersecDomain.models;
using CybersecInfrastructure.Interfaces;
using CybersecInfrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CybersecInfrastructure.Services;

public class AlternativeTitleService : IAlternativeTitleService
{
    
    private readonly CyberSecDbContext _dbContext;
    
    public AlternativeTitleService(CyberSecDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Crée une liste de titres alternatifs pour un profil.
    /// </summary>
    /// <param name="alternativeTitles">La liste des titres alternatifs.</param>
    /// <param name="profileId">L'ID du profil.</param>
    /// <returns>Une instance de <see cref="ServiceResult{T}"/> contenant la liste des titres alternatifs créés.</returns>
    public async Task<ServiceResult<List<AlternativeTitle>>> CreateAlternativeTitles(
        List<string> alternativeTitles,
        uint profileId)
    {
        try
        {
            if (alternativeTitles.Count == 0)
                return ServiceResult<List<AlternativeTitle>>.Failure("Aucun titre alternatif fourni.");

            var altnernativeTitles = alternativeTitles
                .Select(title => new AlternativeTitle
                {
                    ProfileId = profileId,
                    AltTitle = title,
                    CreatedAt = DateTime.UtcNow
                })
                .ToList();

            await _dbContext.AddRangeAsync(altnernativeTitles);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<List<AlternativeTitle>>.Success(altnernativeTitles);
        }
        catch (DbUpdateException dbEx)
        {
            // Erreurs liées à la base de données (ex: clé étrangère invalide)
            return ServiceResult<List<AlternativeTitle>>.Failure($"Erreur BD : {dbEx.InnerException?.Message ?? dbEx.Message}");
        }
        catch (Exception ex)
        {
            // Autres erreurs imprévues
            return ServiceResult<List<AlternativeTitle>>.Failure($"Erreur inattendue : {ex.Message}");
        }
    }


}