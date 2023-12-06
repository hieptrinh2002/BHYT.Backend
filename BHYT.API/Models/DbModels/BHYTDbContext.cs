using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BHYT.API.Models.DbModels;

public partial class BHYTDbContext : DbContext
{
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

        modelBuilder.Entity<Benefit>().HasData(
            new Benefit { Id = 1, Guid = Guid.NewGuid(), Name = "Health Insurance", Description = "Coverage for medical expenses" },
            new Benefit { Id = 2, Guid = Guid.NewGuid(), Name = "Life Insurance", Description = "Coverage in the event of death" }
        );

        modelBuilder.Entity<Compensation>().HasData(
            new Compensation { Id = 1, Guid = Guid.NewGuid(), PolicyId = 1, EmployeeId = 1, Date = DateTime.Now, Amount = 1000.50, Note = "Bonus payment", Status = true },
            new Compensation { Id = 2, Guid = Guid.NewGuid(), PolicyId = 2, EmployeeId = 2, Date = DateTime.Now, Amount = 750.25, Note = "Incentive payment", Status = true }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Guid = Guid.NewGuid(), Username = "user1", Password = "password1", Fullname = "John Doe", Address = "123 Main St", Phone = "1234567890", Birthday = new DateTime(1990, 1, 1), Sex = 1, Email = "user1@example.com", StatusId = 1, RoleId = 1, BankNumber = "1234567890", Bank = "ABC Bank" },
            new Customer { Id = 2, Guid = Guid.NewGuid(), Username = "user2", Password = "password2", Fullname = "Jane Smith", Address = "456 Elm St", Phone = "9876543210", Birthday = new DateTime(1995, 5, 10), Sex = 0, Email = "user2@example.com", StatusId = 1, RoleId = 2, BankNumber = "0987654321", Bank = "XYZ Bank" }
        );
        modelBuilder.Entity<CustomerPolicy>().HasData(
            new CustomerPolicy { Id = 1, Guid = Guid.NewGuid(), CustomerId = 1, StartDate = DateTime.Now, CreatedDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), PremiumAmount = 1000.50, PaymentOption = true, CoverageType = "Comprehensive", DeductibleAmount = 500.00, BenefitId = 1, InsuranceId = 1, LatestUpdate = DateTime.Now, Description = "Policy for car insurance", Status = true, Company = "ABC Insurance" },
            new CustomerPolicy { Id = 2, Guid = Guid.NewGuid(), CustomerId = 2, StartDate = DateTime.Now, CreatedDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), PremiumAmount = 1500.75, PaymentOption = false, CoverageType = "Third Party", DeductibleAmount = 1000.00, BenefitId = 2, InsuranceId = 2, LatestUpdate = DateTime.Now, Description = "Policy for home insurance", Status = true, Company = "XYZ Insurance" }
        );
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Guid = Guid.NewGuid(), Username = "john_doe", Password = "password123", Fullname = "John Doe", Address = "123 Main St", Phone = "1234567890", Birthday = new DateTime(1990, 1, 1), Sex = 0, Email = "john.doe@example.com", StatusId = 1, RoleId = 1 },
            new Employee { Id = 2, Guid = Guid.NewGuid(), Username = "jane_smith", Password = "password456", Fullname = "Jane Smith", Address = "456 Elm St", Phone = "9876543210", Birthday = new DateTime(1995, 5, 10), Sex = 1, Email = "jane.smith@example.com", StatusId = 1, RoleId = 2 }
        );
        modelBuilder.Entity<HealthHistory>().HasData(
            new HealthHistory { Id = 1, Guid = Guid.NewGuid(), CustomerId = 1, InsuranceId = 1, CreatedDate = DateTime.Now, Detail = "Patient's health history detail", Note = "Additional notes about the health history", Diagnostic = "Diagnosis of the patient's condition", HospitalNumber = "123456789", Condition = "health condition" },
            new HealthHistory { Id = 2, Guid = Guid.NewGuid(), CustomerId = 2, InsuranceId = 2, CreatedDate = DateTime.Now, Detail = "Patient's health history detail", Note = "Additional notes about the health history", Diagnostic = "Diagnosis of the patient's condition", HospitalNumber = "987654321", Condition = "health condition" }
            );
        modelBuilder.Entity<Insurance>().HasData(
            new Insurance { Id = 1, Guid = Guid.NewGuid(), Name = "Term Life Insurance", Description = "Provides coverage for a specific term or period of time", InsuranceTypeId = "1", StartAge = 18, EndAge = 65 },
            new Insurance { Id = 2, Guid = Guid.NewGuid(), Name = "Family Health Insurance", Description = "Covers medical expenses for the entire family", InsuranceTypeId = "2", StartAge = 0, EndAge = 99 }
        );

        modelBuilder.Entity<InsurancePayment>().HasData(
            new InsurancePayment { Id = 1, Guid = Guid.NewGuid(), CustomerId = 1, PolicyId = 1, Date = DateTime.Now, Amount = 1000.50, Status = true, Type = "Payment", Note = "Payment for insurance policy" },
            new InsurancePayment { Id = 2, Guid = Guid.NewGuid(), CustomerId = 2, PolicyId = 2, Date = DateTime.Now, Amount = 1500.75, Status = true, Type = "Payment", Note = "Payment for insurance policy" }
        );

        modelBuilder.Entity<InsuranceRequired>().HasData(
        new InsuranceRequired { Id = 1, Guid = Guid.NewGuid(), PolicyId = 1, Status = 1, Date = DateTime.Now, Amount = 500.50, MedicalServiceName = "Medical Checkup", ServiceDescription = "Required annual medical checkup", Note = "Please schedule the appointment." },
        new InsuranceRequired { Id = 2, Guid = Guid.NewGuid(), PolicyId = 2, Status = 1, Date = DateTime.Now, Amount = 1000.75, MedicalServiceName = "Diagnostic Tests", ServiceDescription = "Required diagnostic tests for policy renewal", Note = "Please complete the tests by the specified date." }
        );

        modelBuilder.Entity<InsuranceType>().HasData(
            new InsuranceType { Id = 1, Guid = Guid.NewGuid(), Name = "Life Insurance", Description = "Provides coverage for the risk of life" },
            new InsuranceType { Id = 2, Guid = Guid.NewGuid(), Name = "Health Insurance", Description = "Covers medical expenses and healthcare services" }
        );

        modelBuilder.Entity<PolicyApproval>().HasData(
            new PolicyApproval { Id = 1, Guid = Guid.NewGuid(), PolicyId = 1, EmployeeId = 1, ApprovalDate = DateTime.Now, StatusId = 1 },
            new PolicyApproval { Id = 2, Guid = Guid.NewGuid(), PolicyId = 2, EmployeeId = 2, ApprovalDate = DateTime.Now, StatusId = 2 }
        );
        modelBuilder.Entity<ResetPasswordRequest>().HasData(
            new ResetPasswordRequest { Id = 1, Guid = Guid.NewGuid(), Accountid = "user1@example.com", Resetrequestcode = "ABC123", Requestdate = DateTime.Now, Resetdate = null },
            new ResetPasswordRequest { Id = 2, Guid = Guid.NewGuid(), Accountid = "user2@example.com", Resetrequestcode = "XYZ789", Requestdate = DateTime.Now, Resetdate = null }
        );
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Guid = Guid.NewGuid(), Name = "employee" },
            new Role { Id = 2, Guid = Guid.NewGuid(), Name = "customer" }
        );
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1, Guid = Guid.NewGuid(), Name = true },
            new Status { Id = 2, Guid = Guid.NewGuid(), Name = false }
        );

        base.OnModelCreating(modelBuilder);

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
