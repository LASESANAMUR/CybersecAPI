using CybersecDomain.models;
using CybersecInfrastructure.Services;

namespace CybersecInfrastructure.Interfaces;

public interface ILogoService
{
    public Task<ServiceResult<Logo>> CreateLogoAsync(string url);
}