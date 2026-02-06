using System.Security.Claims;

namespace LMSystem.Web.Auth;

public sealed class AuthSessionStore
{
    private ClaimsPrincipal _principal = new(new ClaimsIdentity());

    public ClaimsPrincipal CurrentPrincipal => _principal;

    public void SignIn(Guid userId, Guid tenantId, string email, IEnumerable<string> roles)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId.ToString()),
            new("tenant_id", tenantId.ToString()),
            new(ClaimTypes.Email, email)
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        _principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "LMSystem"));
    }

    public void SignOut()
    {
        _principal = new ClaimsPrincipal(new ClaimsIdentity());
    }
}
