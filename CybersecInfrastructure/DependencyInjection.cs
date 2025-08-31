
using CybersecInfrastructure.Interfaces;
using CybersecInfrastructure.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CybersecInfrastructure;

//using Microsoft.AspNetCore.SignalR;

public static class DependencyInjection
{
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