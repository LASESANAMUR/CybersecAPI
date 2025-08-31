using CybersecDomain.models;
using CybersecInfrastructure.Services;

namespace CybersecInfrastructure.Interfaces;

public interface IAlternativeTitleService
{
    public Task<ServiceResult<List<AlternativeTitle>>> CreateAlternativeTitles(List<String> alternativeTitles, uint profileId);
}