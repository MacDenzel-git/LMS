namespace DataAccessLayer.Models;

public sealed class School : BaseEntity
{
    public Guid TenantRefId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
