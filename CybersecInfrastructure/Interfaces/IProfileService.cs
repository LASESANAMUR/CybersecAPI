using CybersecDomain.Dtos;
using CybersecDomain.models;
using CybersecInfrastructure.Services;

namespace CybersecInfrastructure.Interfaces;

public interface IProfileService
{
    public Task<ServiceResult<List<ProfileDto>>> GetProfilesAsync();

    public Task<ServiceResult<ProfileDto>> CreateProfileAsync(CreateProfileDto profileDto);
    public Task<ServiceResult<ProfileDto>> DeleteProfileAsync(uint profileId);
    public Task<ServiceResult<ProfileDto>> UpdateProfileAsync(uint profileId, UpdateProfileDto profileDto);
    public Task<ServiceResult<ProfileDto>> GetProfileByIdAsync(uint profileId);
}