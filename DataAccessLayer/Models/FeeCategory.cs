namespace DataAccessLayer.Models;

public sealed class FeeCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsMandatory { get; set; }
}
