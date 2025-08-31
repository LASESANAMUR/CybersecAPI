using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace cybersecAPI.Auth;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly ApiKeyOptions _options;

    public ApiKeyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> schemeOptions,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IOptions<ApiKeyOptions> apiKeyOptions)
        : base(schemeOptions, logger, encoder, clock)
    {
        _options = apiKeyOptions.Value;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (string.IsNullOrWhiteSpace(_options.Key))
        {
            return Task.FromResult(AuthenticateResult.Fail("API key is not configured"));
        }

        if (!Request.Headers.TryGetValue(_options.HeaderName, out var providedKey))
        {
            return Task.FromResult(AuthenticateResult.Fail("Missing API Key"));
        }

        if (!string.Equals(providedKey.ToString(), _options.Key, StringComparison.Ordinal))
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid API Key"));
        }

        var claims = new[] { new Claim(ClaimTypes.Name, "ApiKeyUser") };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
