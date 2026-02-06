using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.TenantServiceContainer;

public sealed class TenantService
{
    private readonly IRepository<Tenant> _tenantRepository;

    public TenantService(IRepository<Tenant> tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public Task<IReadOnlyList<Tenant>> GetTenantsAsync(CancellationToken cancellationToken = default)
    {
        return _tenantRepository.GetAllAsync(cancellationToken);
    }
}
