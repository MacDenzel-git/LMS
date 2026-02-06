using DataAccessLayer.DbContext;
using LMSystem.Web.Auth;

namespace LMSystem.Web.Services;

public sealed class TenantProvider : ITenantProvider
{
    private readonly TenantContext _tenantContext;

    public TenantProvider(TenantContext tenantContext)
    {
        _tenantContext = tenantContext;
    }

    public Guid TenantId => _tenantContext.TenantId ?? Guid.Empty;
}
