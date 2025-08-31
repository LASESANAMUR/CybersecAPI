using CybersecDomain.models;
using CybersecInfrastructure.Services;

namespace CybersecInfrastructure.Interfaces;

public interface IKnowledgeService
{
  public  Task<ServiceResult<List<Knowledge>>> CreateKnowledge(List<string> knowledgeName, uint profileId);
}