using CybersecInfrastructure.Interfaces;
using CybersecDomain.context;
using CybersecDomain.Dtos;
using CybersecDomain.models;
using CybersecInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CybersecInfrastructure.Services;

public class ProfileService : IProfileService
{
    private readonly CyberSecDbContext _dbContext;
    private readonly ILogoService _logoService;
    private readonly IAlternativeTitleService _alternativeTitleService;
    private readonly IDeliverableService _deliverableService;
    private readonly IKnowledgeService _knowledgeService;
    private readonly IKeySkillService _keySkillService;
    private readonly IMainTaskService _mainTaskService;

    public ProfileService(CyberSecDbContext dbContext, ILogoService logoService,
        IAlternativeTitleService alternativeTitleService, IDeliverableService deliverableService,
        IKnowledgeService knoledgeService, IKeySkillService keySkillService, IMainTaskService mainTaskService)
    {
        _dbContext = dbContext;
        _logoService = logoService;
        _alternativeTitleService = alternativeTitleService;
        _deliverableService = deliverableService;
        _knowledgeService = knoledgeService;
        _keySkillService = keySkillService;
        _mainTaskService = mainTaskService;
    }
    
    public async Task<ServiceResult<List<ProfileDto>>> GetProfilesAsync()
    {
        try
        {
            var profiles = await _dbContext.Profiles
                .Include(p => p.AlternativeTitles)
                .Include(p => p.Knowledge)
                .Include(p => p.KeySkill)
                .Include(p => p.Logo)
                .Include(p => p.Deliverables)
                .Include(p => p.MainTasks)
                .Where(p => p.Status != false) // uniquement les profiles actifs
                .Select(p => p.ToDto())
                .ToListAsync();

            return ServiceResult<List<ProfileDto>>.Success(profiles);
        }
        catch (Exception ex)
        {
            return ServiceResult<List<ProfileDto>>.Failure($"An error occurred: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves a profile by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the profile to retrieve.</param>
    /// <returns>A <see cref="ServiceResult{ProfileDto}"/> containing the retrieved profile.</returns>
    /// <response code="200">The profile was retrieved successfully.</response>
    /// <response code="404">The profile was not found.</response>
    public async Task<ServiceResult<ProfileDto>> GetProfileByIdAsync(uint id)
    {
        try
        {
            var profile = await _dbContext.Profiles
                .Include(p => p.AlternativeTitles)
                .Include(p => p.Knowledge)
                .Include(p => p.KeySkill)
                .Include(p => p.Logo)
                .Include(p => p.Deliverables)
                .Include(p => p.MainTasks)
                .SingleOrDefaultAsync(p => p.ProfileId == id);

            return profile != null
                ? ServiceResult<ProfileDto>.Success(profile.ToDto())
                : ServiceResult<ProfileDto>.Failure("Profile not found");
        }
        catch (Exception ex)
        {
            return ServiceResult<ProfileDto>.Failure($"An error occurred: {ex.Message}");
        }
    }

    /// <summary>
    /// Creates a new profile.
    /// </summary>
    /// <param name="profileDto">The data to create the profile with.</param>
    /// <returns>A <see cref="IActionResult"/> containing the result of the creation operation.</returns>
    /// <response code="200">The profile was created successfully.</response>
    /// <response code="400">The profile could not be created.</response>
    public async Task<ServiceResult<ProfileDto>> CreateProfileAsync(CreateProfileDto profileDto)
    {
        try
        {
            dynamic createdLogo = null;
            if (profileDto.LogoUrl != null)
            {

                // Créer le logo
                createdLogo = await _logoService.CreateLogoAsync(profileDto.LogoUrl);
                if (!createdLogo.IsSuccess)
                    return ServiceResult<ProfileDto>.Failure(createdLogo.ErrorMessage);
            }

            // Créer le profile
                var profile = new Profile
                {
                    Title = profileDto.Title,
                    Shortname = profileDto.ShortName,
                    LogoId = createdLogo != null ? createdLogo.Data.LogoId :  null,
                    Mission = profileDto.Mission,
                    SummaryStatement = profileDto.SummaryStatement
                };

                _dbContext.Profiles.Add(profile);
                await _dbContext.SaveChangesAsync(); // 🔹 ProfileId est maintenant disponible
            

            // Créer les alternatives titles avec le ProfileId
            var createdAlternativeTitles =
                await _alternativeTitleService.CreateAlternativeTitles(profileDto.AlternativeTitle.Split(',').ToList(),
                    profile.ProfileId);
            if (!createdAlternativeTitles.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(createdAlternativeTitles.ErrorMessage);

            // Créer les deliverables
            var createdDeliverables =
                await _deliverableService.CreateDeliverables(profileDto.Deliverable.Split(',').ToList(),
                    profile.ProfileId);
            if (!createdDeliverables.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(createdDeliverables.ErrorMessage);
            
            // Créer les Knowledge
            var creadedKnowledge = await _knowledgeService.CreateKnowledge(profileDto.Knowledge.Split(',').ToList(),
                profile.ProfileId);
            if (!creadedKnowledge.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(creadedKnowledge.ErrorMessage);
            
            // Créer les KeySkill
            var createdKeySkill = await _keySkillService.CreateKeySkills(profileDto.KeySkill.Split(',').ToList(),
                profile.ProfileId);
            if (!createdKeySkill.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(createdKeySkill.ErrorMessage);
            
            // Créer les MainTask
            var createdMainTask = await _mainTaskService.CreateMainTask(profileDto.MainTask.Split(',').ToList(),
                profile.ProfileId);
            if (!createdMainTask.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(createdMainTask.ErrorMessage);
            
            
            // Associer et sauvegarder
            profile.AlternativeTitles = createdAlternativeTitles.Data;
            profile.Deliverables = createdDeliverables.Data;
            profile.KeySkill = createdKeySkill.Data;
            await _dbContext.SaveChangesAsync();

            return ServiceResult<ProfileDto>.Success(profile.ToDto());
        }
        catch (Exception ex)
        {
            return ServiceResult<ProfileDto>.Failure($"An error occurred: {ex.Message}");
        }
    }
    
    public async Task<ServiceResult<ProfileDto>> DeleteProfileAsync(uint profileId)
    {
        try
        {
            var profile = await _dbContext.Profiles.SingleOrDefaultAsync(p => p.ProfileId == profileId);
            
            // Verifier si le profile existe
            if (profile == null)
                return ServiceResult<ProfileDto>.Failure("Profile not found");

            profile.Status = false; // désactiver le profile (soft delete)
            await _dbContext.SaveChangesAsync();
            
            return ServiceResult<ProfileDto>.Success(profile.ToDto());
        }
        catch (Exception ex)
        {
            return ServiceResult<ProfileDto>.Failure($"An error occurred: {ex.Message}");
        }
    }

    public async Task<ServiceResult<ProfileDto>> UpdateProfileAsync(uint profileId, UpdateProfileDto profileDto)
    {
        try
        {
            var profile = await _dbContext.Profiles
                .Include(p => p.AlternativeTitles)
                .Include(p => p.Knowledge)
                .Include(p => p.KeySkill)
                .Include(p => p.Logo)
                .Include(p => p.Deliverables)
                .Include(p => p.MainTasks)
                .SingleOrDefaultAsync(p => p.ProfileId == profileId);

            if (profile == null)
                return ServiceResult<ProfileDto>.Failure("Profile not found");

            // Update scalar properties
            profile.Title = profileDto.Title;
            profile.Shortname = profileDto.ShortName;
            profile.Mission = profileDto.Mission;
            profile.SummaryStatement = profileDto.SummaryStatement;

            // Update Logo
            if (profileDto.LogoUrl != null)
            {
                var createdLogo = await _logoService.CreateLogoAsync(profileDto.LogoUrl);
                if (!createdLogo.IsSuccess)
                    return ServiceResult<ProfileDto>.Failure(createdLogo.ErrorMessage);
              

                profile.LogoId = createdLogo.Data.LogoId;
            }
            var oldLogo = profile.Logo;

            await _dbContext.SaveChangesAsync();
            if (oldLogo != null)
            {
               
                _dbContext.Logos.Remove(oldLogo);
            }

            // Update related collections by removing old and adding new
            _dbContext.AlternativeTitles.RemoveRange(profile.AlternativeTitles);
            _dbContext.Deliverable.RemoveRange(profile.Deliverables);
            _dbContext.Knowledge.RemoveRange(profile.Knowledge);
            _dbContext.KeySkills.RemoveRange(profile.KeySkill);
            _dbContext.MainTasks.RemoveRange(profile.MainTasks);

            var createdAlternativeTitles =
                await _alternativeTitleService.CreateAlternativeTitles(profileDto.AlternativeTitle.Split(',').ToList(),
                    profile.ProfileId);
            if (!createdAlternativeTitles.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(createdAlternativeTitles.ErrorMessage);

            var createdDeliverables =
                await _deliverableService.CreateDeliverables(profileDto.Deliverable.Split(',').ToList(),
                    profile.ProfileId);
            if (!createdDeliverables.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(createdDeliverables.ErrorMessage);

            var creadedKnowledge = await _knowledgeService.CreateKnowledge(profileDto.Knowledge.Split(',').ToList(),
                profile.ProfileId);
            if (!creadedKnowledge.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(creadedKnowledge.ErrorMessage);

            var createdKeySkill = await _keySkillService.CreateKeySkills(profileDto.KeySkill.Split(',').ToList(),
                profile.ProfileId);
            if (!createdKeySkill.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(createdKeySkill.ErrorMessage);

            var createdMainTask = await _mainTaskService.CreateMainTask(profileDto.MainTask.Split(',').ToList(),
                profile.ProfileId);
            if (!createdMainTask.IsSuccess)
                return ServiceResult<ProfileDto>.Failure(createdMainTask.ErrorMessage);

            profile.AlternativeTitles = createdAlternativeTitles.Data;
            profile.Deliverables = createdDeliverables.Data;
            profile.Knowledge = creadedKnowledge.Data;
            profile.KeySkill = createdKeySkill.Data;
            profile.MainTasks = createdMainTask.Data;

            await _dbContext.SaveChangesAsync();

            return ServiceResult<ProfileDto>.Success(profile.ToDto());
        }
        catch (Exception ex)
        {
            return ServiceResult<ProfileDto>.Failure($"An error occurred: {ex.Message}");
        }
    }
}