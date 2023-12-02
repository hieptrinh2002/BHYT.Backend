using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BHYT.API.Models.DbModels;

public partial class BHYTDbContext : DbContext
{
    public BHYTDbContext(IConfiguration configuration)
    {
    }

    public BHYTDbContext(DbContextOptions<BHYTDbContext> options): base(options)
    {
    }

    public virtual DbSet<Benefit> Benefits { get; set; }

    public virtual DbSet<Compensation> Compensations { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerPolicy> CustomerPolicies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<HealthHistory> HealthHistories { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<InsurancePayment> InsurancePayments { get; set; }

    public virtual DbSet<InsuranceRequired> InsuranceRequireds { get; set; }

    public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }

    public virtual DbSet<PolicyApproval> PolicyApprovals { get; set; }

    public virtual DbSet<ResetPasswordRequest> ResetPasswordRequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-GFADSU2\\MSSQLSERVER01;Initial Catalog=PTUD_BHYT;Integrated Security=True;TrustServerCertificate=True");
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
  
        modelBuilder.Entity<Benefit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("BENEFIT_PK");

            entity.ToTable("BENEFIT");

            entity.HasIndex(e => e.Guid, "UQ__BENEFIT__15B69B8F92DB0273").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Compensation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("COMPENSATION_PK");

            entity.ToTable("COMPENSATION");

            entity.HasIndex(e => e.Guid, "UQ__COMPENSA__15B69B8F37DC82A4").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("DATE");
            entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("NOTE");
            entity.Property(e => e.PolicyId).HasColumnName("POLICY_ID");
            entity.Property(e => e.Status).HasColumnName("STATUS");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CUSTOMER_PK");

            entity.ToTable("CUSTOMER");

            entity.HasIndex(e => e.Guid, "UQ__CUSTOMER__15B69B8F12620E9E").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Bank)
                .HasMaxLength(30)
                .HasColumnName("BANK");
            entity.Property(e => e.BankNumber)
                .HasMaxLength(30)
                .HasColumnName("BANK_NUMBER");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("BIRTHDAY");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("PHONE");
            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.Sex).HasColumnName("SEX");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<CustomerPolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CUSTOMER_POLICIES_PK");

            entity.ToTable("CUSTOMER_POLICIES");

            entity.HasIndex(e => e.Guid, "UQ__CUSTOMER__15B69B8FBD3D10F9").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BenefitId).HasColumnName("BENEFIT_ID");
            entity.Property(e => e.Company)
                .HasMaxLength(30)
                .HasColumnName("COMPANY");
            entity.Property(e => e.CoverageType)
                .HasMaxLength(20)
                .HasColumnName("COVERAGE_TYPE");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.DeductibleAmount).HasColumnName("DEDUCTIBLE_AMOUNT");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("END_DATE");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.InsuranceId).HasColumnName("INSURANCE_ID");
            entity.Property(e => e.LatestUpdate)
                .HasColumnType("date")
                .HasColumnName("LATEST_UPDATE");
            entity.Property(e => e.PaymentOption).HasColumnName("PAYMENT_OPTION");
            entity.Property(e => e.PremiumAmount).HasColumnName("PREMIUM_AMOUNT");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("START_DATE");
            entity.Property(e => e.Status).HasColumnName("STATUS");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EMPLOYEE_PK");

            entity.ToTable("EMPLOYEE");

            entity.HasIndex(e => e.Guid, "UQ__EMPLOYEE__15B69B8FBFD72589").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("BIRTHDAY");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("PHONE");
            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.Sex).HasColumnName("SEX");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<HealthHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("HEALTH_HISTORY_PK");

            entity.ToTable("HEALTH_HISTORY");

            entity.HasIndex(e => e.Guid, "UQ__HEALTH_H__15B69B8FAD12E3E0").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Condition)
                .HasMaxLength(30)
                .HasColumnName("CONDITION");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.Detail)
                .HasMaxLength(200)
                .HasColumnName("DETAIL");
            entity.Property(e => e.Diagnostic)
                .HasMaxLength(100)
                .HasColumnName("DIAGNOSTIC");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.HospitalNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HOSPITAL_NUMBER");
            entity.Property(e => e.InsuranceId).HasColumnName("INSURANCE_ID");
            entity.Property(e => e.Note)
                .HasMaxLength(100)
                .HasColumnName("NOTE");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("INSURANCE_PK");

            entity.ToTable("INSURANCE");

            entity.HasIndex(e => e.Guid, "UQ__INSURANC__15B69B8FDF297966").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.EndAge).HasColumnName("END_AGE");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.InsuranceTypeId)
                .HasMaxLength(30)
                .HasColumnName("INSURANCE_TYPE_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");
            entity.Property(e => e.StartAge).HasColumnName("START_AGE");
        });

        modelBuilder.Entity<InsurancePayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("INSURANCE_PAYMENT_PK");

            entity.ToTable("INSURANCE_PAYMENT");

            entity.HasIndex(e => e.Guid, "UQ__INSURANC__15B69B8F6483C5CF").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("DATE");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOTE");
            entity.Property(e => e.PolicyId).HasColumnName("POLICY_ID");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<InsuranceRequired>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("INSURANCE_REQUIRED_PK");

            entity.ToTable("INSURANCE_REQUIRED");

            entity.HasIndex(e => e.Guid, "UQ__INSURANC__15B69B8F061E3A3B").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("DATE");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.MedicalServiceName)
                .HasMaxLength(30)
                .HasColumnName("MEDICAL_SERVICE_NAME");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("NOTE");
            entity.Property(e => e.PolicyId).HasColumnName("POLICY_ID");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(255)
                .HasColumnName("SERVICE_DESCRIPTION");
            entity.Property(e => e.Status).HasColumnName("STATUS");
        });

        modelBuilder.Entity<InsuranceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("INSURANCE_TYPE_PK");

            entity.ToTable("INSURANCE_TYPE");

            entity.HasIndex(e => e.Guid, "UQ__INSURANC__15B69B8F8ABB27D4").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<PolicyApproval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("POLICY_APPROVAL_PK");

            entity.ToTable("POLICY_APPROVAL");

            entity.HasIndex(e => e.Guid, "UQ__POLICY_A__15B69B8FFD1FBDBA").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("date")
                .HasColumnName("APPROVAL_DATE");
            entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.PolicyId).HasColumnName("POLICY_ID");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
        });

        modelBuilder.Entity<ResetPasswordRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RESET_PASSWORD_REQUEST_PK");

            entity.ToTable("RESET_PASSWORD_REQUEST");

            entity.HasIndex(e => e.Guid, "UQ__RESET_PA__15B69B8F0CE555AB").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Accountid)
                .HasMaxLength(30)
                .HasColumnName("ACCOUNTID");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Requestdate)
                .HasColumnType("datetime")
                .HasColumnName("REQUESTDATE");
            entity.Property(e => e.Resetdate)
                .HasColumnType("datetime")
                .HasColumnName("RESETDATE");
            entity.Property(e => e.Resetrequestcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RESETREQUESTCODE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ROLE_PK");

            entity.ToTable("ROLE");

            entity.HasIndex(e => e.Guid, "UQ__ROLE__15B69B8FAB73D4EE").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SESSION_PK");

            entity.ToTable("SESSION");

            entity.HasIndex(e => e.Guid, "UQ__SESSION__15B69B8FE2E4485C").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(30)
                .HasColumnName("ACCOUNT_ID");
            entity.Property(e => e.Appversion)
                .HasMaxLength(255)
                .HasColumnName("APPVERSION");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.IsValid).HasColumnName("IS_VALID");
            entity.Property(e => e.LOginDate)
                .HasColumnType("date")
                .HasColumnName("lOGIN_DATE");
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(255)
                .HasColumnName("SERVICE_DESCRIPTION");
            entity.Property(e => e.SessionLastIp)
                .HasMaxLength(255)
                .HasColumnName("SESSION_LAST_IP");
            entity.Property(e => e.SessionLastRefresh)
                .HasColumnType("date")
                .HasColumnName("SESSION_LAST_REFRESH");
            entity.Property(e => e.SessionToken)
                .HasMaxLength(255)
                .HasColumnName("SESSION_TOKEN");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("STATUS_PK");

            entity.ToTable("STATUS");

            entity.HasIndex(e => e.Guid, "UQ__STATUS__15B69B8F10330BE7").IsUnique();

            entity.HasIndex(e => e.Guid, "idx_GUID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GUID");
            entity.Property(e => e.Name).HasColumnName("NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
