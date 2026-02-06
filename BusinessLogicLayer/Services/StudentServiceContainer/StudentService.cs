using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.StudentServiceContainer;

public sealed class StudentService
{
    private readonly IRepository<Student> _studentRepository;

    public StudentService(IRepository<Student> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task<IReadOnlyList<Student>> GetStudentsAsync(CancellationToken cancellationToken = default)
    {
        return _studentRepository.GetAllAsync(cancellationToken);
    }

    public Task AddStudentAsync(Student student, CancellationToken cancellationToken = default)
    {
        return _studentRepository.AddAsync(student, cancellationToken);
    }
}
