namespace DataAccessLayer.DTOs;

public sealed class FeeStatementDto
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public decimal TotalBilled { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal TotalDiscounts { get; set; }
    public decimal TotalPenalties { get; set; }
    public decimal Outstanding => TotalBilled + TotalPenalties - TotalDiscounts - TotalPaid;
}
