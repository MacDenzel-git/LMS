using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.ClassServiceContainer;

public sealed class ClassService
{
    private readonly IRepository<ClassRoom> _classRepository;

    public ClassService(IRepository<ClassRoom> classRepository)
    {
        _classRepository = classRepository;
    }

    public Task<IReadOnlyList<ClassRoom>> GetClassesAsync(CancellationToken cancellationToken = default)
    {
        return _classRepository.GetAllAsync(cancellationToken);
    }
}
