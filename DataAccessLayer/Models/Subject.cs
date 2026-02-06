namespace DataAccessLayer.Models;

public sealed class Subject : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Code { get; set; }
}
