namespace DataAccessLayer.DTOs;

public sealed class StudentDto
{
    public Guid Id { get; set; }
    public string AdmissionNumber { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public Guid ClassId { get; set; }
    public bool IsActive { get; set; }
}
