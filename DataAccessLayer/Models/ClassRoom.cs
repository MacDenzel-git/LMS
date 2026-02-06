namespace DataAccessLayer.Models;

public sealed class ClassRoom : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
