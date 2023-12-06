using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BHYT.API.Migrations
{
    /// <inheritdoc />
    public partial class Insertdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BENEFIT",
                columns: new[] { "ID", "DESCRIPTION", "GUID", "NAME" },
                values: new object[,]
                {
                    { 1, "Coverage for medical expenses", new Guid("d78daed5-1780-4965-8ba0-5ca8596edfbf"), "Health Insurance" },
                    { 2, "Coverage in the event of death", new Guid("f62ffd62-41a4-4324-be80-ed45ca4ee2ab"), "Life Insurance" }
                });

            migrationBuilder.InsertData(
                table: "COMPENSATION",
                columns: new[] { "ID", "AMOUNT", "DATE", "EMPLOYEE_ID", "GUID", "NOTE", "POLICY_ID", "STATUS" },
                values: new object[,]
                {
                    { 1, 1000.5, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1427), 1, new Guid("36d1b847-6aab-4d0c-8699-fd696cea8a2a"), "Bonus payment", 1, true },
                    { 2, 750.25, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1474), 2, new Guid("d5821556-5a68-4ee4-aa7f-40b625e37b1d"), "Incentive payment", 2, true }
                });

            migrationBuilder.InsertData(
                table: "CUSTOMER",
                columns: new[] { "ID", "ADDRESS", "BANK", "BANK_NUMBER", "BIRTHDAY", "EMAIL", "FULLNAME", "GUID", "PASSWORD", "PHONE", "ROLE_ID", "SEX", "STATUS_ID", "USERNAME" },
                values: new object[,]
                {
                    { 1, "123 Main St", "ABC Bank", "1234567890", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "John Doe", new Guid("4596f5ae-1ea1-4a97-8100-f32f42b1dd20"), "password1", "1234567890", 1, 1, 1, "user1" },
                    { 2, "456 Elm St", "XYZ Bank", "0987654321", new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "Jane Smith", new Guid("552c5144-960a-4d1e-a676-9de26f3215d5"), "password2", "9876543210", 2, 0, 1, "user2" }
                });

            migrationBuilder.InsertData(
                table: "CUSTOMER_POLICIES",
                columns: new[] { "ID", "BENEFIT_ID", "COMPANY", "COVERAGE_TYPE", "CREATED_DATE", "CUSTOMER_ID", "DEDUCTIBLE_AMOUNT", "DESCRIPTION", "END_DATE", "GUID", "INSURANCE_ID", "LATEST_UPDATE", "PAYMENT_OPTION", "PREMIUM_AMOUNT", "START_DATE", "STATUS" },
                values: new object[,]
                {
                    { 1, 1, "ABC Insurance", "Comprehensive", new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1524), 1, 500.0, "Policy for car insurance", new DateTime(2024, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1526), new Guid("4a5560fa-78c8-415f-b917-123ef9262254"), 1, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1535), true, 1000.5, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1524), true },
                    { 2, 2, "XYZ Insurance", "Third Party", new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1540), 2, 1000.0, "Policy for home insurance", new DateTime(2024, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1540), new Guid("6050d149-81f3-4bd2-b27e-b034e6d8bdc2"), 2, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1542), false, 1500.75, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1539), true }
                });

            migrationBuilder.InsertData(
                table: "EMPLOYEE",
                columns: new[] { "ID", "ADDRESS", "BIRTHDAY", "EMAIL", "FULLNAME", "GUID", "PASSWORD", "PHONE", "ROLE_ID", "SEX", "STATUS_ID", "USERNAME" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", new Guid("c79e05c6-9055-47cf-b48f-15e7df8b5d34"), "password123", "1234567890", 1, 0, 1, "john_doe" },
                    { 2, "456 Elm St", new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", new Guid("c3b17a21-9086-492f-a709-1b2e7beab17a"), "password456", "9876543210", 2, 1, 1, "jane_smith" }
                });

            migrationBuilder.InsertData(
                table: "HEALTH_HISTORY",
                columns: new[] { "ID", "CONDITION", "CREATED_DATE", "CUSTOMER_ID", "DETAIL", "DIAGNOSTIC", "GUID", "HOSPITAL_NUMBER", "INSURANCE_ID", "NOTE" },
                values: new object[,]
                {
                    { 1, "health condition", new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1591), 1, "Patient's health history detail", "Diagnosis of the patient's condition", new Guid("6a256382-a087-444a-87eb-893af4570f9b"), "123456789", 1, "Additional notes about the health history" },
                    { 2, "health condition", new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1596), 2, "Patient's health history detail", "Diagnosis of the patient's condition", new Guid("1cb37c52-ede5-4b83-a5a3-1dcdd96e3b85"), "987654321", 2, "Additional notes about the health history" }
                });

            migrationBuilder.InsertData(
                table: "INSURANCE",
                columns: new[] { "ID", "DESCRIPTION", "END_AGE", "GUID", "INSURANCE_TYPE_ID", "NAME", "START_AGE" },
                values: new object[,]
                {
                    { 1, "Provides coverage for a specific term or period of time", (byte)65, new Guid("61f7819f-7ca6-450e-bd40-9bca05b1d4ca"), "1", "Term Life Insurance", (byte)18 },
                    { 2, "Covers medical expenses for the entire family", (byte)99, new Guid("879e5a79-b68e-45c5-923b-3f2985503728"), "2", "Family Health Insurance", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "INSURANCE_PAYMENT",
                columns: new[] { "ID", "AMOUNT", "CUSTOMER_ID", "DATE", "GUID", "NOTE", "POLICY_ID", "STATUS", "TYPE" },
                values: new object[,]
                {
                    { 1, 1000.5, 1, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1637), new Guid("4040b994-b304-42b9-b8b2-1f43931aa1a3"), "Payment for insurance policy", 1, true, "Payment" },
                    { 2, 1500.75, 2, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1643), new Guid("09357e35-951b-4d5e-affe-d2adf4255bd4"), "Payment for insurance policy", 2, true, "Payment" }
                });

            migrationBuilder.InsertData(
                table: "INSURANCE_REQUIRED",
                columns: new[] { "ID", "AMOUNT", "DATE", "GUID", "MEDICAL_SERVICE_NAME", "NOTE", "POLICY_ID", "SERVICE_DESCRIPTION", "STATUS" },
                values: new object[,]
                {
                    { 1, 500.5, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1659), new Guid("bbef834b-db83-4dd9-bc8b-b50ceb8ab353"), "Medical Checkup", "Please schedule the appointment.", 1, "Required annual medical checkup", 1 },
                    { 2, 1000.75, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1662), new Guid("59f60b72-2677-4beb-97bf-59c667a3b608"), "Diagnostic Tests", "Please complete the tests by the specified date.", 2, "Required diagnostic tests for policy renewal", 1 }
                });

            migrationBuilder.InsertData(
                table: "INSURANCE_TYPE",
                columns: new[] { "ID", "DESCRIPTION", "GUID", "NAME" },
                values: new object[,]
                {
                    { 1, "Provides coverage for the risk of life", new Guid("4a65ea10-a7f4-4d6c-a346-f3cb4c07f48c"), "Life Insurance" },
                    { 2, "Covers medical expenses and healthcare services", new Guid("95967557-5290-4cdd-9322-f874cf936b0d"), "Health Insurance" }
                });

            migrationBuilder.InsertData(
                table: "POLICY_APPROVAL",
                columns: new[] { "ID", "APPROVAL_DATE", "EMPLOYEE_ID", "GUID", "POLICY_ID", "STATUS_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1692), 1, new Guid("eeec7bfa-eb5e-40ae-8180-9add7cb2a3a7"), 1, 1 },
                    { 2, new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1694), 2, new Guid("253a199a-06f4-4f91-b35c-909b8855a941"), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "RESET_PASSWORD_REQUEST",
                columns: new[] { "ID", "ACCOUNTID", "GUID", "REQUESTDATE", "RESETDATE", "RESETREQUESTCODE" },
                values: new object[,]
                {
                    { 1, "user1@example.com", new Guid("ac27666b-f749-4d9e-b351-731abc735325"), new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1713), null, "ABC123" },
                    { 2, "user2@example.com", new Guid("8429c658-ad20-430a-a007-7fa1c64abf05"), new DateTime(2023, 12, 6, 17, 30, 24, 695, DateTimeKind.Local).AddTicks(1716), null, "XYZ789" }
                });

            migrationBuilder.InsertData(
                table: "ROLE",
                columns: new[] { "ID", "GUID", "NAME" },
                values: new object[,]
                {
                    { 1, new Guid("ddba4218-b9f4-4c6f-9e96-71d1e612a409"), "employee" },
                    { 2, new Guid("a4352dfa-11ae-431e-adb8-b859ff206390"), "customer" }
                });

            migrationBuilder.InsertData(
                table: "STATUS",
                columns: new[] { "ID", "GUID", "NAME" },
                values: new object[,]
                {
                    { 1, new Guid("6315cd4d-0cc1-4e9d-80bd-08b7cd680d53"), true },
                    { 2, new Guid("a4e7da11-1b42-4aa8-8f21-99927bbc2231"), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BENEFIT",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BENEFIT",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "COMPENSATION",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "COMPENSATION",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CUSTOMER",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CUSTOMER",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CUSTOMER_POLICIES",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CUSTOMER_POLICIES",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EMPLOYEE",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EMPLOYEE",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HEALTH_HISTORY",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HEALTH_HISTORY",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "INSURANCE",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "INSURANCE",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "INSURANCE_PAYMENT",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "INSURANCE_PAYMENT",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "INSURANCE_REQUIRED",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "INSURANCE_REQUIRED",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "INSURANCE_TYPE",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "INSURANCE_TYPE",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "POLICY_APPROVAL",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "POLICY_APPROVAL",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RESET_PASSWORD_REQUEST",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RESET_PASSWORD_REQUEST",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ROLE",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ROLE",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "STATUS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "STATUS",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
