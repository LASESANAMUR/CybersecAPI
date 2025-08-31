using CybersecDomain.models;

namespace CybersecDomain.Dtos;

public static class EntityExtensions
{
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
    
    public static KeySkillDto ToDto(this KeySkill ks)
    {
        return new KeySkillDto
        {
            KeySkillId = ks.KeySkillId,
            Skill = ks.Skill,
            CreatedAt = ks.CreatedAt
        };
    }

    public static KnowledgeDto ToDto(this Knowledge k)
    {
        return new KnowledgeDto
        {
            KnowledgeName = k.KnowledgeName,
            CreatedAt = k.CreatedAt
        };
    }

    public static DeliverableDto ToDto(this Deliverable deliverable)
    {
        return new DeliverableDto
        {
            DeliverableName = deliverable.DeliverableName,
            CreatedAt = deliverable.CreatedAt
        };
    }
    
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

    public static LogoDto ToDto(this Logo logo)
    {
        return new LogoDto
        {
            LogoId = logo.LogoId,
            Url = logo.Url
        };
    }
}
