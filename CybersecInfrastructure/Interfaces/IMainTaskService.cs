using CybersecDomain.models;
using CybersecInfrastructure.Services;

namespace CybersecInfrastructure.Interfaces;

public interface IMainTaskService
{
    public Task<ServiceResult<List<MainTask>>> CreateMainTask(List<string> task, uint profileId);
}