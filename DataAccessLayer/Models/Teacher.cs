namespace DataAccessLayer.Models;

public sealed class Teacher : BaseEntity
{
    public string StaffNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
