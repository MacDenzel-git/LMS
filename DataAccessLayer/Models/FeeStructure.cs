namespace DataAccessLayer.Models;

public sealed class FeeStructure : BaseEntity
{
    public Guid FeeCategoryId { get; set; }
    public Guid ClassRoomId { get; set; }
    public Guid AcademicYearId { get; set; }
    public Guid TermId { get; set; }
    public decimal Amount { get; set; }
    public bool IsOptional { get; set; }
}
