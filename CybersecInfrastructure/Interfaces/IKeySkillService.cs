using CybersecDomain.models;
using CybersecInfrastructure.Services;

namespace CybersecInfrastructure.Interfaces;

public interface IKeySkillService
{
    public Task<ServiceResult<List<KeySkill>>> CreateKeySkills(List<String> skill, uint profileId);
}