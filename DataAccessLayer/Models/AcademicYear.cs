namespace DataAccessLayer.Models;

public sealed class AcademicYear : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartsOn { get; set; }
    public DateTime EndsOn { get; set; }
}
