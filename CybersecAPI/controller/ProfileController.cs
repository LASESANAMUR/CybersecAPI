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
    
    public Profile(IProfileService profileService)
    {
        _profileService = profileService;
    }
    
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