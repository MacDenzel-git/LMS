using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.TeacherServiceContainer;

public sealed class TeacherService
{
    private readonly IRepository<Teacher> _teacherRepository;

    public TeacherService(IRepository<Teacher> teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public Task<IReadOnlyList<Teacher>> GetTeachersAsync(CancellationToken cancellationToken = default)
    {
        return _teacherRepository.GetAllAsync(cancellationToken);
    }
}
