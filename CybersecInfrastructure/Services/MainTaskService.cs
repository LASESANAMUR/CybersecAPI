using CybersecDomain.context;
using CybersecDomain.models;
using CybersecInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CybersecInfrastructure.Services;

public class MainTaskService : IMainTaskService
{
    private readonly CyberSecDbContext _dbContext;

    public MainTaskService(CyberSecDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ServiceResult<List<MainTask>>> CreateMainTask(List<string> task, uint profileId)
    {
        try
        {
           var mainTasks = new List<MainTask>();
            foreach (string t in task)
            {
                mainTasks.Add(new MainTask { Task = t,  ProfileId= profileId });
            }
            await _dbContext.MainTasks.AddRangeAsync(mainTasks);
            await _dbContext.SaveChangesAsync();
            return ServiceResult<List<MainTask>>.Success(mainTasks);
        }
        catch (DbUpdateException ex)
        {
            // Erreur spécifique à la base de données
            return ServiceResult<List<MainTask>>.Failure($"Erreur lors de l'enregistrement en base : {ex.Message}");
        }
        catch (Exception ex)
        {
            // Erreur inattendue
            return ServiceResult<List<MainTask>>.Failure($"Erreur inattendue : {ex.Message}");
        }
    }
}