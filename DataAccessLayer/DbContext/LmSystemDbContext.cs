using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbContext;

public sealed class LmSystemDbContext : DbContext
{
    private readonly ITenantProvider _tenantProvider;

    public LmSystemDbContext(DbContextOptions<LmSystemDbContext> options, ITenantProvider tenantProvider)
        : base(options)
    {
        _tenantProvider = tenantProvider;
    }

    public DbSet<Tenant> Tenants => base.Set<Tenant>();
    public DbSet<School> Schools => base.Set<School>();
    public DbSet<User> Users => base.Set<User>();
    public DbSet<Role> Roles => base.Set<Role>();
    public DbSet<UserRole> UserRoles => base.Set<UserRole>();
    public DbSet<Student> Students => base.Set<Student>();
    public DbSet<Teacher> Teachers => base.Set<Teacher>();
    public DbSet<ClassRoom> Classes => base.Set<ClassRoom>();
    public DbSet<Subject> Subjects => base.Set<Subject>();
    public DbSet<ClassSubject> ClassSubjects => base.Set<ClassSubject>();
    public DbSet<AcademicYear> AcademicYears => base.Set<AcademicYear>();
    public DbSet<Term> Terms => base.Set<Term>();
    public DbSet<FeeCategory> FeeCategories => base.Set<FeeCategory>();
    public DbSet<FeeStructure> FeeStructures => base.Set<FeeStructure>();
    public DbSet<StudentFee> StudentFees => base.Set<StudentFee>();
    public DbSet<Payment> Payments => base.Set<Payment>();
    public DbSet<Discount> Discounts => base.Set<Discount>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ApplyQueryFilters(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Id = entry.Entity.Id == Guid.Empty ? Guid.NewGuid() : entry.Entity.Id;
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.TenantId = entry.Entity.TenantId == Guid.Empty ? _tenantProvider.TenantId : entry.Entity.TenantId;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyQueryFilters(ModelBuilder modelBuilder)
    {
        var tenantId = _tenantProvider.TenantId;

        modelBuilder.Entity<Tenant>().HasQueryFilter(entity => !entity.IsDeleted);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType) && entityType.ClrType != typeof(Tenant))
            {
                var method = typeof(LmSystemDbContext)
                    .GetMethod(nameof(SetTenantFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!
                    .MakeGenericMethod(entityType.ClrType);

                method.Invoke(null, new object[] { modelBuilder, tenantId });
            }
        }
    }

    private static void SetTenantFilter<TEntity>(ModelBuilder modelBuilder, Guid tenantId) where TEntity : BaseEntity
    {
        modelBuilder.Entity<TEntity>().HasQueryFilter(entity => !entity.IsDeleted && entity.TenantId == tenantId);
    }
}
