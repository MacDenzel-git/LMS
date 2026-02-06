using BusinessLogicLayer.Services.ClassServiceContainer;
using BusinessLogicLayer.Services.FeesServiceContainer;
using BusinessLogicLayer.Services.PaymentsServiceContainer;
using BusinessLogicLayer.Services.RoleServiceContainer;
using BusinessLogicLayer.Services.SchoolServiceContainer;
using BusinessLogicLayer.Services.StudentServiceContainer;
using BusinessLogicLayer.Services.SubjectServiceContainer;
using BusinessLogicLayer.Services.TeacherServiceContainer;
using BusinessLogicLayer.Services.TenantServiceContainer;
using BusinessLogicLayer.Services.UserServiceContainer;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer;

public static class DependencyInjectionRegistration
{
    public static IServiceCollection AddLmSystemServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Student>, Repository<Student>>();
        services.AddScoped<IRepository<Teacher>, Repository<Teacher>>();
        services.AddScoped<IRepository<ClassRoom>, Repository<ClassRoom>>();
        services.AddScoped<IRepository<Subject>, Repository<Subject>>();
        services.AddScoped<IRepository<ClassSubject>, Repository<ClassSubject>>();
        services.AddScoped<IRepository<FeeCategory>, Repository<FeeCategory>>();
        services.AddScoped<IRepository<FeeStructure>, Repository<FeeStructure>>();
        services.AddScoped<IRepository<StudentFee>, Repository<StudentFee>>();
        services.AddScoped<IRepository<Payment>, Repository<Payment>>();
        services.AddScoped<IRepository<Discount>, Repository<Discount>>();
        services.AddScoped<IRepository<AcademicYear>, Repository<AcademicYear>>();
        services.AddScoped<IRepository<Term>, Repository<Term>>();
        services.AddScoped<IRepository<Role>, Repository<Role>>();
        services.AddScoped<IRepository<User>, Repository<User>>();
        services.AddScoped<IRepository<UserRole>, Repository<UserRole>>();
        services.AddScoped<IRepository<School>, Repository<School>>();
        services.AddScoped<IRepository<Tenant>, Repository<Tenant>>();

        services.AddScoped<StudentService>();
        services.AddScoped<TeacherService>();
        services.AddScoped<ClassService>();
        services.AddScoped<SubjectService>();
        services.AddScoped<FeesService>();
        services.AddScoped<PaymentsService>();
        services.AddScoped<UserService>();
        services.AddScoped<RoleService>();
        services.AddScoped<SchoolService>();
        services.AddScoped<TenantService>();

        return services;
    }
}
