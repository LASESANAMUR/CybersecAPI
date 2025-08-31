using CybersecDomain.models;
using CybersecInfrastructure.Services;

namespace CybersecInfrastructure.Interfaces;

public interface IDeliverableService
{
    public Task<ServiceResult<List<Deliverable>>> CreateDeliverables(List<string> DeliverableName, uint profileId);
}