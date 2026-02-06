namespace DataAccessLayer.Models;

public sealed class Student : BaseEntity
{
    public string AdmissionNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Guid ClassId { get; set; }
    public bool IsActive { get; set; }
}
