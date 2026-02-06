namespace DataAccessLayer.Models;

public sealed class Tenant : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string SubscriptionPlan { get; set; } = "Free";
}
