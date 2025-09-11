using CybersecDomain.models;

namespace CybersecDomain.Dtos;

public static class EntityExtensions
{
    /// <summary>
    /// Converts the given <see cref="Profile"/> to a <see cref="ProfileDto"/>.
    /// </summary>
    /// <param name="profile">The <see cref="Profile"/> to convert.</param>
    /// <returns>A <see cref="ProfileDto"/> that represents the given <see cref="Profile"/>.</returns>
    public static ProfileDto ToDto(this Profile? profile)
    {
        if (profile is null) return new ProfileDto();

        return new ProfileDto
        {
            ProfileId = profile.ProfileId,
            Title = profile.Title,
            Shortname = profile.Shortname,
            SummaryStatement = profile.SummaryStatement,
            Mission = profile.Mission,
            Status = profile.Status,
            Logo = profile.Logo?.ToDto(),

            AlternativeTitles = profile.AlternativeTitles?
                .Select(at => at.AltTitle)
                .ToList(),

            KeySkill = profile.KeySkill?.Select(ks => ks.ToDto()).ToList(),

            Knowledge = profile.Knowledge?.Select(k => k.ToDto()).ToList(),

            Deliverables = profile.Deliverables?.Select(d => d.ToDto()).ToList(),

            MainTasks = profile.MainTasks?.Select(mt => mt.ToDto()).ToList(),
        };
    }
    
    /// <summary>
    /// Converts the given <see cref="KeySkill"/> to a <see cref="KeySkillDto"/>.
    /// </summary>
    /// <param name="ks">The <see cref="KeySkill"/> to convert.</param>
    /// <returns>A <see cref="KeySkillDto"/> that represents the given <see cref="KeySkill"/>.</returns>
    public static KeySkillDto ToDto(this KeySkill ks)
    {
        return new KeySkillDto
        {
            KeySkillId = ks.KeySkillId,
            Skill = ks.Skill,
            CreatedAt = ks.CreatedAt
        };
    }

    /// <summary>
    /// Converts the given <see cref="Knowledge"/> to a <see cref="KnowledgeDto"/>.
    /// </summary>
    /// <param name="k">The <see cref="Knowledge"/> to convert.</param>
    /// <returns>A <see cref="KnowledgeDto"/> that represents the given <see cref="Knowledge"/>.</returns>
    public static KnowledgeDto ToDto(this Knowledge k)
    {
        return new KnowledgeDto
        {
            KnowledgeName = k.KnowledgeName,
            CreatedAt = k.CreatedAt
        };
    }

    /// <summary>
    /// Converts the given <see cref="Deliverable"/> to a <see cref="DeliverableDto"/>.
    /// </summary>
    /// <param name="deliverable">The <see cref="Deliverable"/> to convert.</param>
    /// <returns>A <see cref="DeliverableDto"/> that represents the given <see cref="Deliverable"/>.</returns>
    public static DeliverableDto ToDto(this Deliverable deliverable)
    {
        return new DeliverableDto
        {
            DeliverableName = deliverable.DeliverableName,
            CreatedAt = deliverable.CreatedAt
        };
    }
    
    /// <summary>
    /// Converts the given <see cref="MainTask"/> to a <see cref="MainTaskDto"/>.
    /// </summary>
    /// <param name="mainTask">The <see cref="MainTask"/> to convert.</param>
    /// <returns>A <see cref="MainTaskDto"/> that represents the given <see cref="MainTask"/>.</returns>
    public static MainTaskDto ToDto(this MainTask mainTask)
    {
        return new MainTaskDto
        {
            MainTaskId = mainTask.MainTaskId,
            Task = mainTask.Task,
            CreatedAt = mainTask.CreatedAt,
            UpdatedAt = mainTask.UpdatedAt
        };
    }

    /// <summary>
    /// Converts the given <see cref="Logo"/> to a <see cref="LogoDto"/>.
    /// </summary>
    /// <param name="logo">The <see cref="Logo"/> to convert.</param>
    /// <returns>A <see cref="LogoDto"/> that represents the given <see cref="Logo"/>.</returns>
    public static LogoDto ToDto(this Logo logo)
    {
        return new LogoDto
        {
            LogoId = logo.LogoId,
            LogoUrl = logo.Url
        };
    }
}
