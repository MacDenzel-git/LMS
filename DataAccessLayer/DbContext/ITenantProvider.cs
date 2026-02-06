namespace DataAccessLayer.DbContext;

public interface ITenantProvider
{
    Guid TenantId { get; }
}
