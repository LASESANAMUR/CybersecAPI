using CybersecDomain.context;
using CybersecDomain.models;
using CybersecInfrastructure.Interfaces;
using CybersecInfrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CybersecInfrastructure.Services;

public class DeliverableService : IDeliverableService
{
    private readonly CyberSecDbContext _dbContext;

    public DeliverableService(CyberSecDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Crée une liste de livrables liés à un profile en base de données.
    /// </summary>
    /// <param name="deliverableNames">Liste des noms de livrables à créer.</param>
    /// <param name="profileId">Identifiant du profile lié aux livrables à créer.</param>
    /// <returns>Un objet <see cref="ServiceResult{List{Deliverable}}"/> contenant la liste des livrables créés en cas de succès, ou un message d'erreur en cas d'échec.</returns>
    public async Task<ServiceResult<List<Deliverable>>> CreateDeliverables(List<string> deliverableNames, uint profileId)
    {
        try
        {
            // Varification qu'il y ait des delivrables
            if (deliverableNames.Count == 0)
                return ServiceResult<List<Deliverable>>.Failure("Aucun livrable fourni.");

            // Création de la liste des livrables
            var deliverables = deliverableNames
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .Select(name => new Deliverable
                {
                    ProfileId = profileId,
                    DeliverableName = name.Trim(),
                    CreatedAt = DateTime.UtcNow
                })
                .ToList();

            if (deliverables.Count == 0)
                return ServiceResult<List<Deliverable>>.Failure("Tous les noms de livrables sont vides ou invalides.");

            // Insertion en base
            await _dbContext.Deliverable.AddRangeAsync(deliverables);
            await _dbContext.SaveChangesAsync();

            return ServiceResult<List<Deliverable>>.Success(deliverables);
        }
        catch (DbUpdateException ex)
        {
            // Erreur spécifique à la base de données
            return ServiceResult<List<Deliverable>>.Failure($"Erreur lors de l'enregistrement en base : {ex.Message}");
        }
        catch (Exception ex)
        {
            // Erreur inattendue
            return ServiceResult<List<Deliverable>>.Failure($"Erreur inattendue : {ex.Message}");
        }
    }

}