using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.SchoolServiceContainer;

public sealed class SchoolService
{
    private readonly IRepository<School> _schoolRepository;

    public SchoolService(IRepository<School> schoolRepository)
    {
        _schoolRepository = schoolRepository;
    }

    public Task<IReadOnlyList<School>> GetSchoolsAsync(CancellationToken cancellationToken = default)
    {
        return _schoolRepository.GetAllAsync(cancellationToken);
    }
}
