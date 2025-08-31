namespace cybersecAPI.Auth;

public class ApiKeyOptions
{
    public string HeaderName { get; set; } = "X-Api-Key";
    public string? Key { get; set; }
}
