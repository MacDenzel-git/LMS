using Common.Enums;

namespace DataAccessLayer.Models;

public sealed class Payment : BaseEntity
{
    public Guid StudentFeeId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime PaidOn { get; set; }
    public string? Reference { get; set; }
}
