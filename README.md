# LMSystem – Multi-Tenant School Management SaaS

## Project Overview
LMSystem is a production-grade, multi-tenant School Management SaaS designed for commercial resale. It delivers a secure, scalable platform for multiple schools to manage students, staff, and finances within a single application.

## Architecture
- **Presentation**: Blazor Server (Interactive Server) in `LMSystem.Web`.
- **Business Logic**: Service containers in `BusinessLogicLayer`.
- **Data Access**: EF Core with repository pattern in `DataAccessLayer`.
- **Shared**: Common enums, constants, and helpers in `Common`.

## Multi-Tenancy Strategy
- **Logical multi-tenancy** with a shared database.
- Every business table includes `TenantId`.
- `ITenantProvider` resolves the active tenant from the scoped context.
- Global query filters enforce tenant isolation and soft delete behavior.

## Fees Module
The Fees module supports:
- Fee categories and fee structures by class, academic year, and term.
- Student fee ledgers, discounts, penalties, and partial payments.
- Payment methods (Cash, Bank, Mobile Money).
- Statements and balances for finance reporting.

## Running Locally
1. Ensure SQL Server is available.
2. Configure the connection string in `LMSystem.Web/appsettings.json`.
3. Run the app:
   ```bash
   dotnet run --project LMSystem.Web
   ```

## Default Credentials (Seed Data Placeholder)
- **SuperAdmin**: superadmin@lmsystem.local / ChangeMe123!

## Solution Structure
```
LMSystem.sln
├── LMSystem.Web
├── BusinessLogicLayer
├── DataAccessLayer
└── Common
```

## Notes
- Custom authentication (no ASP.NET Identity).
- Password hashing uses BCrypt.
- Soft deletes and audit fields are enabled on all models.
