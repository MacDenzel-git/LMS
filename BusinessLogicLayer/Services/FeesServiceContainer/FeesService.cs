using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.FeesServiceContainer;

public sealed class FeesService
{
    private readonly IRepository<FeeCategory> _feeCategoryRepository;
    private readonly IRepository<FeeStructure> _feeStructureRepository;
    private readonly IRepository<StudentFee> _studentFeeRepository;

    public FeesService(
        IRepository<FeeCategory> feeCategoryRepository,
        IRepository<FeeStructure> feeStructureRepository,
        IRepository<StudentFee> studentFeeRepository)
    {
        _feeCategoryRepository = feeCategoryRepository;
        _feeStructureRepository = feeStructureRepository;
        _studentFeeRepository = studentFeeRepository;
    }

    public Task<IReadOnlyList<FeeCategory>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return _feeCategoryRepository.GetAllAsync(cancellationToken);
    }

    public Task AddFeeStructureAsync(FeeStructure feeStructure, CancellationToken cancellationToken = default)
    {
        return _feeStructureRepository.AddAsync(feeStructure, cancellationToken);
    }

    public async Task<FeeStatementDto> GetStatementAsync(Student student, CancellationToken cancellationToken = default)
    {
        var fees = await _studentFeeRepository.GetAllAsync(cancellationToken);
        var studentFees = fees.Where(fee => fee.StudentId == student.Id).ToList();

        return new FeeStatementDto
        {
            StudentId = student.Id,
            StudentName = $"{student.FirstName} {student.LastName}",
            TotalBilled = studentFees.Sum(fee => fee.Amount),
            TotalPaid = studentFees.Sum(fee => fee.AmountPaid),
            TotalDiscounts = studentFees.Sum(fee => fee.DiscountAmount),
            TotalPenalties = studentFees.Sum(fee => fee.PenaltyAmount)
        };
    }
}
