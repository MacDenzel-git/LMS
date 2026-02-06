using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.PaymentsServiceContainer;

public sealed class PaymentsService
{
    private readonly IRepository<Payment> _paymentRepository;
    private readonly IRepository<StudentFee> _studentFeeRepository;

    public PaymentsService(IRepository<Payment> paymentRepository, IRepository<StudentFee> studentFeeRepository)
    {
        _paymentRepository = paymentRepository;
        _studentFeeRepository = studentFeeRepository;
    }

    public async Task RecordPaymentAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        await _paymentRepository.AddAsync(payment, cancellationToken);

        var studentFee = await _studentFeeRepository.GetByIdAsync(payment.StudentFeeId, cancellationToken);
        if (studentFee is null)
        {
            return;
        }

        studentFee.AmountPaid += payment.Amount;
        studentFee.IsCleared = studentFee.AmountPaid + studentFee.DiscountAmount >= studentFee.Amount + studentFee.PenaltyAmount;
        await _studentFeeRepository.UpdateAsync(studentFee, cancellationToken);
    }
}
