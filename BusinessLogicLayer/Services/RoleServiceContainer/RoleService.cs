using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.RoleServiceContainer;

public sealed class RoleService
{
    private readonly IRepository<Role> _roleRepository;

    public RoleService(IRepository<Role> roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<IReadOnlyList<Role>> GetRolesAsync(CancellationToken cancellationToken = default)
    {
        return _roleRepository.GetAllAsync(cancellationToken);
    }
}
