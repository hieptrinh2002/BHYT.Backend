using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BHYT.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loginattempts = table.Column<int>(name: "login_attempts", type: "int", nullable: false),
                    lastfailedlogin = table.Column<DateTime>(name: "last_failed_login", type: "datetime2", nullable: true),
                    islocked = table.Column<bool>(name: "is_locked", type: "bit", nullable: false),
                    lockeduntil = table.Column<DateTime>(name: "locked_until", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compensations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compensations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PremiumAmount = table.Column<double>(type: "float", nullable: true),
                    PaymentOption = table.Column<bool>(type: "bit", nullable: true),
                    CoverageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeductibleAmount = table.Column<double>(type: "float", nullable: true),
                    BenefitId = table.Column<int>(type: "int", nullable: true),
                    InsuranceId = table.Column<int>(type: "int", nullable: true),
                    LatestUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    InsuranceId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequireds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    MedicalServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequireds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartAge = table.Column<byte>(type: "tinyint", nullable: true),
                    EndAge = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyApprovals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessTokenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResetPasswordRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resetrequestcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requestdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resetdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetPasswordRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Appversion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionLastIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionLastRefresh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "Id", "Description", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, "Coverage for medical expenses", new Guid("3dfc0b67-0246-471e-919a-aa9013819d3e"), "Health Insurance" },
                    { 2, "Coverage in the event of death", new Guid("84cd0bf0-bbe6-4886-a1de-c899a520ac06"), "Life Insurance" }
                });

            migrationBuilder.InsertData(
                table: "Compensations",
                columns: new[] { "Id", "Amount", "Date", "EmployeeId", "Guid", "Note", "PolicyId", "Status" },
                values: new object[,]
                {
                    { 1, 1000.5, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5548), 1, new Guid("708503fe-395a-4fcd-897a-889a537883ad"), "Bonus payment", 1, true },
                    { 2, 750.25, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5570), 2, new Guid("553c70d6-3e42-400b-bad5-00c597952aa6"), "Incentive payment", 2, true }
                });

            migrationBuilder.InsertData(
                table: "CustomerPolicies",
                columns: new[] { "Id", "BenefitId", "Company", "CoverageType", "CreatedDate", "CustomerId", "DeductibleAmount", "Description", "EndDate", "Guid", "InsuranceId", "LatestUpdate", "PaymentOption", "PremiumAmount", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, "ABC Insurance", "Comprehensive", new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5594), 1, 500.0, "Policy for car insurance", new DateTime(2024, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5595), new Guid("cc5af0f2-61cc-488e-ac28-bf4a174e37cd"), 1, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5604), true, 1000.5, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5592), true },
                    { 2, 2, "XYZ Insurance", "Third Party", new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5611), 2, 1000.0, "Policy for home insurance", new DateTime(2024, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5612), new Guid("cda8aca2-00e0-498f-b198-b787d87bb250"), 2, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5615), false, 1500.75, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5611), true }
                });

            migrationBuilder.InsertData(
                table: "HealthHistories",
                columns: new[] { "Id", "Condition", "CreatedDate", "CustomerId", "Detail", "Diagnostic", "Guid", "HospitalNumber", "InsuranceId", "Note" },
                values: new object[,]
                {
                    { 1, "health condition", new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5638), 1, "Patient's health history detail", "Diagnosis of the patient's condition", new Guid("996f6052-2b6d-4bb9-bd19-094c6bc7c744"), "123456789", 1, "Additional notes about the health history" },
                    { 2, "health condition", new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5642), 2, "Patient's health history detail", "Diagnosis of the patient's condition", new Guid("24f30cbc-4cd9-446f-8edc-5387145be5a2"), "987654321", 2, "Additional notes about the health history" }
                });

            migrationBuilder.InsertData(
                table: "InsurancePayments",
                columns: new[] { "Id", "Amount", "CustomerId", "Date", "Guid", "Note", "PolicyId", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1000.5, 1, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5690), new Guid("1ed66998-197e-43d2-bc15-c1da1d0912fc"), "Payment for insurance policy", 1, true, "Payment" },
                    { 2, 1500.75, 2, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5695), new Guid("7c982732-b3ae-45c8-9d9e-a78607c8ce87"), "Payment for insurance policy", 2, true, "Payment" }
                });

            migrationBuilder.InsertData(
                table: "InsuranceRequireds",
                columns: new[] { "Id", "Amount", "Date", "Guid", "MedicalServiceName", "Note", "PolicyId", "ServiceDescription", "Status" },
                values: new object[,]
                {
                    { 1, 500.5, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5717), new Guid("69c15c0f-be0f-44b0-87e9-93554e6418af"), "Medical Checkup", "Please schedule the appointment.", 1, "Required annual medical checkup", 1 },
                    { 2, 1000.75, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5722), new Guid("81d90aa9-d98f-4fdd-9037-51efc1d48286"), "Diagnostic Tests", "Please complete the tests by the specified date.", 2, "Required diagnostic tests for policy renewal", 1 }
                });

            migrationBuilder.InsertData(
                table: "InsuranceTypes",
                columns: new[] { "Id", "Description", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, "Provides coverage for the risk of life", new Guid("7d549713-a040-4349-a6ad-549ae4f22160"), "Life Insurance" },
                    { 2, "Covers medical expenses and healthcare services", new Guid("79ae196e-6312-4c37-9487-056914b9eb79"), "Health Insurance" }
                });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "Description", "EndAge", "Guid", "InsuranceTypeId", "Name", "StartAge" },
                values: new object[,]
                {
                    { 1, "Provides coverage for a specific term or period of time", (byte)65, new Guid("5d41c2d2-2ceb-4fc6-9f2b-68c64d4e71f7"), "1", "Term Life Insurance", (byte)18 },
                    { 2, "Covers medical expenses for the entire family", (byte)99, new Guid("8cafde3d-7f85-4c1c-9a15-54ae66d94ecf"), "2", "Family Health Insurance", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "PolicyApprovals",
                columns: new[] { "Id", "ApprovalDate", "EmployeeId", "Guid", "PolicyId", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5761), 1, new Guid("e4255ce2-9271-4e2b-a7eb-9ca311cb99d2"), 1, 1 },
                    { 2, new DateTime(2023, 12, 28, 14, 48, 48, 100, DateTimeKind.Local).AddTicks(5765), 2, new Guid("2ceb1ce5-3eda-4e43-ba4b-35093a150e4f"), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("fb732651-e84b-4177-bd66-915111268843"), "employee" },
                    { 2, new Guid("559a29b1-93a1-4165-897b-3eaef5f3b1ae"), "customer" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("b19de646-7bf9-4175-bc6b-fbfb6edbdb9a"), true },
                    { 2, new Guid("e83efe99-bcfb-43b6-b3f4-102bb69ef483"), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Compensations");

            migrationBuilder.DropTable(
                name: "CustomerPolicies");

            migrationBuilder.DropTable(
                name: "HealthHistories");

            migrationBuilder.DropTable(
                name: "InsurancePayments");

            migrationBuilder.DropTable(
                name: "InsuranceRequireds");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "InsuranceTypes");

            migrationBuilder.DropTable(
                name: "PolicyApprovals");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ResetPasswordRequests");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
