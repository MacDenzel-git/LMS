using Common.Constants;
using Common.Helpers;
using DataAccessLayer.Models;

namespace DataAccessLayer.DbContext;

public static class SeedData
{
    public static void Seed(LmSystemDbContext dbContext)
    {
        if (dbContext.Tenants.Any())
        {
            return;
        }

        var tenant = new Tenant
        {
            Id = SystemConstants.SuperAdminTenantId,
            Name = "LMSystem SaaS",
            IsActive = true,
            SubscriptionPlan = "Free"
        };

        var school = new School
        {
            TenantId = tenant.Id,
            TenantRefId = tenant.Id,
            Address = "Sample Road",
            Phone = "+000000000",
            Email = "contact@sample.edu"
        };

        var superAdmin = new User
        {
            TenantId = tenant.Id,
            Email = SystemConstants.SuperAdminEmail,
            FirstName = "Super",
            LastName = "Admin",
            PasswordHash = PasswordHasher.HashPassword(SystemConstants.DefaultPassword),
            IsActive = true
        };

        dbContext.Tenants.Add(tenant);
        dbContext.Schools.Add(school);
        dbContext.Users.Add(superAdmin);
        dbContext.SaveChanges();
    }
}
