using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BHYT.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
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
                name: "ResetPasswordRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Accountid = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LOginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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

            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "Id", "Description", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, "Coverage for medical expenses", new Guid("698e5c48-6fda-4715-9b72-61d8a657462c"), "Health Insurance" },
                    { 2, "Coverage in the event of death", new Guid("a2300e98-53cb-45c8-ada7-5193802fa50c"), "Life Insurance" }
                });

            migrationBuilder.InsertData(
                table: "Compensations",
                columns: new[] { "Id", "Amount", "Date", "EmployeeId", "Guid", "Note", "PolicyId", "Status" },
                values: new object[,]
                {
                    { 1, 1000.5, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2629), 1, new Guid("17a41d93-b2d9-4c8c-87dc-6b4d5b72b0b2"), "Bonus payment", 1, true },
                    { 2, 750.25, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2651), 2, new Guid("892a74de-10b4-4ead-8416-cc0dd6db88f3"), "Incentive payment", 2, true }
                });

            migrationBuilder.InsertData(
                table: "CustomerPolicies",
                columns: new[] { "Id", "BenefitId", "Company", "CoverageType", "CreatedDate", "CustomerId", "DeductibleAmount", "Description", "EndDate", "Guid", "InsuranceId", "LatestUpdate", "PaymentOption", "PremiumAmount", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, "ABC Insurance", "Comprehensive", new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2700), 1, 500.0, "Policy for car insurance", new DateTime(2024, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2701), new Guid("bde6a876-d5b4-40d7-969a-71132c231aa0"), 1, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2709), true, 1000.5, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2699), true },
                    { 2, 2, "XYZ Insurance", "Third Party", new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2713), 2, 1000.0, "Policy for home insurance", new DateTime(2024, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2713), new Guid("279b9080-f40e-4bf4-8185-06b75b2c7dfa"), 2, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2719), false, 1500.75, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2712), true }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Bank", "BankNumber", "Birthday", "Email", "Fullname", "Guid", "Password", "Phone", "RoleId", "Sex", "StatusId", "Username" },
                values: new object[,]
                {
                    { 1, "123 Main St", "ABC Bank", "1234567890", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "John Doe", new Guid("83085ca8-163e-4a41-a013-1d6a9796be0b"), "password1", "1234567890", 1, 1, 1, "user1" },
                    { 2, "456 Elm St", "XYZ Bank", "0987654321", new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "Jane Smith", new Guid("c4da4e81-0e55-46ee-b58e-0f95204c8929"), "password2", "9876543210", 2, 0, 1, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Birthday", "Email", "Fullname", "Guid", "Password", "Phone", "RoleId", "Sex", "StatusId", "Username" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", new Guid("a0c1a5b2-3173-4709-9d41-01708d4643f1"), "password123", "1234567890", 1, 0, 1, "john_doe" },
                    { 2, "456 Elm St", new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", new Guid("407663bd-4052-4e0e-9371-4ca248947d0d"), "password456", "9876543210", 2, 1, 1, "jane_smith" }
                });

            migrationBuilder.InsertData(
                table: "HealthHistories",
                columns: new[] { "Id", "Condition", "CreatedDate", "CustomerId", "Detail", "Diagnostic", "Guid", "HospitalNumber", "InsuranceId", "Note" },
                values: new object[,]
                {
                    { 1, "health condition", new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2765), 1, "Patient's health history detail", "Diagnosis of the patient's condition", new Guid("9781f0cc-b1f9-4c59-a6a9-43ab2c747bae"), "123456789", 1, "Additional notes about the health history" },
                    { 2, "health condition", new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2772), 2, "Patient's health history detail", "Diagnosis of the patient's condition", new Guid("63f69f8b-b490-4841-ae01-d7f8b361080e"), "987654321", 2, "Additional notes about the health history" }
                });

            migrationBuilder.InsertData(
                table: "InsurancePayments",
                columns: new[] { "Id", "Amount", "CustomerId", "Date", "Guid", "Note", "PolicyId", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1000.5, 1, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2855), new Guid("dd0a25f7-ac45-452a-951a-7425807a27a2"), "Payment for insurance policy", 1, true, "Payment" },
                    { 2, 1500.75, 2, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2862), new Guid("ba1a2a94-1a43-47d9-a49f-cc3d8d4c7590"), "Payment for insurance policy", 2, true, "Payment" }
                });

            migrationBuilder.InsertData(
                table: "InsuranceRequireds",
                columns: new[] { "Id", "Amount", "Date", "Guid", "MedicalServiceName", "Note", "PolicyId", "ServiceDescription", "Status" },
                values: new object[,]
                {
                    { 1, 500.5, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2888), new Guid("e2cee227-0bde-4ad0-81e7-30cebc86bdbb"), "Medical Checkup", "Please schedule the appointment.", 1, "Required annual medical checkup", 1 },
                    { 2, 1000.75, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2893), new Guid("a4390601-4c76-4910-9214-bf91ae1b35cc"), "Diagnostic Tests", "Please complete the tests by the specified date.", 2, "Required diagnostic tests for policy renewal", 1 }
                });

            migrationBuilder.InsertData(
                table: "InsuranceTypes",
                columns: new[] { "Id", "Description", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, "Provides coverage for the risk of life", new Guid("26be99c4-6b5c-492e-af6e-27135be27032"), "Life Insurance" },
                    { 2, "Covers medical expenses and healthcare services", new Guid("e4f75223-1eb5-42c8-a02c-d1bb0e01fdf6"), "Health Insurance" }
                });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "Description", "EndAge", "Guid", "InsuranceTypeId", "Name", "StartAge" },
                values: new object[,]
                {
                    { 1, "Provides coverage for a specific term or period of time", (byte)65, new Guid("ad80e263-10f0-4136-bf01-2a6f4e2ae0a2"), "1", "Term Life Insurance", (byte)18 },
                    { 2, "Covers medical expenses for the entire family", (byte)99, new Guid("87af9c70-3096-45dc-adf8-1fab6ae1a880"), "2", "Family Health Insurance", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "PolicyApprovals",
                columns: new[] { "Id", "ApprovalDate", "EmployeeId", "Guid", "PolicyId", "StatusId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2925), 1, new Guid("34d0d383-2d53-4ed2-8418-a8c87307aedf"), 1, 1 },
                    { 2, new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2928), 2, new Guid("c52c2b5b-655c-4719-a0f1-971e4402ce7a"), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ResetPasswordRequests",
                columns: new[] { "Id", "Accountid", "Guid", "Requestdate", "Resetdate", "Resetrequestcode" },
                values: new object[,]
                {
                    { 1, "user1@example.com", new Guid("0d6cbf79-1c33-4028-8c72-8be92508867a"), new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2944), null, "ABC123" },
                    { 2, "user2@example.com", new Guid("fe93a51e-b6d5-497f-b32b-7bae13962b16"), new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2947), null, "XYZ789" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("d283c884-be45-4a31-88cf-19d138669205"), "employee" },
                    { 2, new Guid("35cb2e87-0ec2-43ec-b5eb-7ac703f26197"), "customer" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("893527de-d105-434f-a3af-afc73138bf95"), true },
                    { 2, new Guid("e2df9c6b-c755-43b2-84c1-cc2624aa74c3"), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Compensations");

            migrationBuilder.DropTable(
                name: "CustomerPolicies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

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
                name: "ResetPasswordRequests");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
