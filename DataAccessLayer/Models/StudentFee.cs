namespace DataAccessLayer.Models;

public sealed class StudentFee : BaseEntity
{
    public Guid StudentId { get; set; }
    public Guid FeeStructureId { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal PenaltyAmount { get; set; }
    public bool IsCleared { get; set; }
}
