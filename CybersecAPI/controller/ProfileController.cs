using CybersecDomain.Dtos;
using CybersecInfrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CybersecAPI.controller;

[ApiController]
[Authorize(AuthenticationSchemes = "ApiKey")]
public class Profile : ControllerBase
{
    private readonly IProfileService _profileService;
    
/// <summary>
/// Initializes a new instance of the <see cref="Profile"/> controller.
/// </summary>
/// <param name="profileService">The profile service used for profile operations.</param>
    public Profile(IProfileService profileService)
    {
        _profileService = profileService;
    }
    /// <summary>
    /// Gets all profiles.
    /// </summary>
    /// <returns>A <see cref="IActionResult"/> containing the result of the retrieval operation.</returns>
    /// <response code="200">The profiles were retrieved successfully.</response>
    /// <response code="400">The profiles could not be retrieved.</response>
    //
    [HttpGet]
    [Route("profiles")]
    public async Task<IActionResult> Profiles()
    {
        var result = await _profileService.GetProfilesAsync();
        
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.ErrorMessage); 
    }
    
    /// <summary>
    /// Creates a new profile.
    /// </summary>
    /// <param name="profileDto">The data to create the profile with.</param>
    /// <returns>A <see cref="IActionResult"/> containing the result of the creation operation.</returns>
    /// <response code="200">The profile was created successfully.</response>
    /// <response code="400">The profile could not be created.</response>
    [HttpPost]
    [Route("profiles")]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileDto profileDto)
    {

        var result = await _profileService.CreateProfileAsync(profileDto);
        
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.ErrorMessage);
        
    }
  
    /// <summary>
    /// Deletes a profile by its identifier.
    /// </summary>
    /// <param name="profileId">The identifier of the profile to delete.</param>
    /// <returns>A <see cref="IActionResult"/> containing the result of the deletion operation.</returns>
    /// <response code="200">The profile was deleted successfully.</response>
    /// <response code="400">The profile could not be deleted.</response>
    [HttpDelete]
    [Route("profiles/{profileId}")]
    public async Task<IActionResult> DeleteProfile(uint profileId)
    {
        var result = await _profileService.DeleteProfileAsync(profileId);
        
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.ErrorMessage);
    }
    /// <summary>
    /// Retrieves a profile by its identifier.
    /// </summary>
    /// <param name="profileId">The identifier of the profile to retrieve.</param>
    /// <returns>A <see cref="IActionResult"/> containing the result of the retrieval operation.</returns>
    /// <response code="200">The profile was retrieved successfully.</response>
    /// <response code="404">The profile was not found.</response>
    /// <response code="400">The profile could not be retrieved.</response>
    [HttpGet]
    [Route("profiles/{profileId}")]
    public async Task<IActionResult> GetProfile(uint profileId)
    {
        var result = await _profileService.GetProfileByIdAsync(profileId);
    
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
    
        if (result.ErrorMessage.Contains("not found"))
        {
            return NotFound();
        }
    
        return BadRequest(result.ErrorMessage);
    }
    
    /// <summary>
    /// Updates an existing profile.
    /// </summary>
    /// <param name="profileId">The identifier of the profile to update.</param>
    /// <param name="profileDto">The data to update the profile with.</param>
    /// <returns>A <see cref="IActionResult"/> containing the result of the update operation.</returns>
    /// <response code="200">The profile was updated successfully.</response>
    /// <response code="400">The profile could not be updated.</response>
    [HttpPut]
    [Route("profiles/{profileId}")]
    public async Task<IActionResult> UpdateProfile(uint profileId, [FromBody] UpdateProfileDto profileDto)
    {

        var result = await _profileService.UpdateProfileAsync(profileId, profileDto);
        
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.ErrorMessage);
        
    }
}