namespace DataAccessLayer.Models;

public sealed class Discount : BaseEntity
{
    public Guid StudentFeeId { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
}
