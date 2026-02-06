namespace DataAccessLayer.Models;

public sealed class Term : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid AcademicYearId { get; set; }
    public DateTime StartsOn { get; set; }
    public DateTime EndsOn { get; set; }
}
