using Microsoft.AspNetCore.Components.Authorization;

namespace LMSystem.Web.Auth;

public sealed class SessionAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthSessionStore _sessionStore;

    public SessionAuthenticationStateProvider(AuthSessionStore sessionStore)
    {
        _sessionStore = sessionStore;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_sessionStore.CurrentPrincipal));
    }

    public void NotifyAuthenticationChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
