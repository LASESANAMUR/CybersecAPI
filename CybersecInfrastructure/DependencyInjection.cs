
using CybersecInfrastructure.Interfaces;
using CybersecInfrastructure.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CybersecInfrastructure;

//using Microsoft.AspNetCore.SignalR;

public static class DependencyInjection
{
    
    /// <summary>
    /// Adds the services provided by the CybersecInfrastructure project
    /// to the provided IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to which the services
    /// will be added.</param>
    public static void AddInfrastructure(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IAlternativeTitleService, AlternativeTitleService>();
        services.AddScoped<IKeySkillService, keySkillService>();
        services.AddScoped<ILogoService, LogoService>();
        services.AddScoped<IDeliverableService, DeliverableService>();
        services.AddScoped<IKnowledgeService, KnowledgeService>();
        services.AddScoped<IMainTaskService, MainTaskService>();
    }
}