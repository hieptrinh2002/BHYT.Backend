using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHYT.API.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BENEFIT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BENEFIT_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMPENSATION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    POLICYID = table.Column<int>(name: "POLICY_ID", type: "int", nullable: true),
                    EMPLOYEEID = table.Column<int>(name: "EMPLOYEE_ID", type: "int", nullable: true),
                    DATE = table.Column<DateTime>(type: "date", nullable: true),
                    AMOUNT = table.Column<double>(type: "float", nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COMPENSATION_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    USERNAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FULLNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    BIRTHDAY = table.Column<DateTime>(type: "date", nullable: true),
                    SEX = table.Column<int>(type: "int", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STATUSID = table.Column<int>(name: "STATUS_ID", type: "int", nullable: true),
                    ROLEID = table.Column<int>(name: "ROLE_ID", type: "int", nullable: true),
                    BANKNUMBER = table.Column<string>(name: "BANK_NUMBER", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BANK = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CUSTOMER_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_POLICIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    CUSTOMERID = table.Column<int>(name: "CUSTOMER_ID", type: "int", nullable: true),
                    STARTDATE = table.Column<DateTime>(name: "START_DATE", type: "date", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(name: "CREATED_DATE", type: "date", nullable: true),
                    ENDDATE = table.Column<DateTime>(name: "END_DATE", type: "date", nullable: true),
                    PREMIUMAMOUNT = table.Column<double>(name: "PREMIUM_AMOUNT", type: "float", nullable: true),
                    PAYMENTOPTION = table.Column<bool>(name: "PAYMENT_OPTION", type: "bit", nullable: true),
                    COVERAGETYPE = table.Column<string>(name: "COVERAGE_TYPE", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DEDUCTIBLEAMOUNT = table.Column<double>(name: "DEDUCTIBLE_AMOUNT", type: "float", nullable: true),
                    BENEFITID = table.Column<int>(name: "BENEFIT_ID", type: "int", nullable: true),
                    INSURANCEID = table.Column<int>(name: "INSURANCE_ID", type: "int", nullable: true),
                    LATESTUPDATE = table.Column<DateTime>(name: "LATEST_UPDATE", type: "date", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true),
                    COMPANY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CUSTOMER_POLICIES_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    USERNAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    FULLNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    BIRTHDAY = table.Column<DateTime>(type: "date", nullable: true),
                    SEX = table.Column<int>(type: "int", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    STATUSID = table.Column<int>(name: "STATUS_ID", type: "int", nullable: true),
                    ROLEID = table.Column<int>(name: "ROLE_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EMPLOYEE_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HEALTH_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    CUSTOMERID = table.Column<int>(name: "CUSTOMER_ID", type: "int", nullable: true),
                    INSURANCEID = table.Column<int>(name: "INSURANCE_ID", type: "int", nullable: true),
                    CREATEDDATE = table.Column<DateTime>(name: "CREATED_DATE", type: "date", nullable: true),
                    DETAIL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DIAGNOSTIC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HOSPITALNUMBER = table.Column<string>(name: "HOSPITAL_NUMBER", type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CONDITION = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("HEALTH_HISTORY_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSURANCE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    INSURANCETYPEID = table.Column<string>(name: "INSURANCE_TYPE_ID", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    STARTAGE = table.Column<byte>(name: "START_AGE", type: "tinyint", nullable: true),
                    ENDAGE = table.Column<byte>(name: "END_AGE", type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("INSURANCE_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSURANCE_PAYMENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    CUSTOMERID = table.Column<int>(name: "CUSTOMER_ID", type: "int", nullable: true),
                    POLICYID = table.Column<int>(name: "POLICY_ID", type: "int", nullable: true),
                    DATE = table.Column<DateTime>(type: "date", nullable: true),
                    AMOUNT = table.Column<double>(type: "float", nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true),
                    TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NOTE = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("INSURANCE_PAYMENT_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSURANCE_REQUIRED",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    POLICYID = table.Column<int>(name: "POLICY_ID", type: "int", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    DATE = table.Column<DateTime>(type: "date", nullable: true),
                    AMOUNT = table.Column<double>(type: "float", nullable: true),
                    MEDICALSERVICENAME = table.Column<string>(name: "MEDICAL_SERVICE_NAME", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SERVICEDESCRIPTION = table.Column<string>(name: "SERVICE_DESCRIPTION", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("INSURANCE_REQUIRED_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSURANCE_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("INSURANCE_TYPE_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "POLICY_APPROVAL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    POLICYID = table.Column<int>(name: "POLICY_ID", type: "int", nullable: true),
                    EMPLOYEEID = table.Column<int>(name: "EMPLOYEE_ID", type: "int", nullable: true),
                    APPROVALDATE = table.Column<DateTime>(name: "APPROVAL_DATE", type: "date", nullable: true),
                    STATUSID = table.Column<int>(name: "STATUS_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("POLICY_APPROVAL_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESET_PASSWORD_REQUEST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    ACCOUNTID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RESETREQUESTCODE = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    REQUESTDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    RESETDATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RESET_PASSWORD_REQUEST_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ROLE_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SESSION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    ACCOUNTID = table.Column<string>(name: "ACCOUNT_ID", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    lOGINDATE = table.Column<DateTime>(name: "lOGIN_DATE", type: "date", nullable: true),
                    APPVERSION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SESSIONLASTIP = table.Column<string>(name: "SESSION_LAST_IP", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SESSIONLASTREFRESH = table.Column<DateTime>(name: "SESSION_LAST_REFRESH", type: "date", nullable: true),
                    SESSIONTOKEN = table.Column<string>(name: "SESSION_TOKEN", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SERVICEDESCRIPTION = table.Column<string>(name: "SERVICE_DESCRIPTION", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ISVALID = table.Column<int>(name: "IS_VALID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SESSION_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STATUS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    NAME = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("STATUS_PK", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "BENEFIT",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__BENEFIT__15B69B8F92DB0273",
                table: "BENEFIT",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "COMPENSATION",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__COMPENSA__15B69B8F37DC82A4",
                table: "COMPENSATION",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "CUSTOMER",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__CUSTOMER__15B69B8F12620E9E",
                table: "CUSTOMER",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "CUSTOMER_POLICIES",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__CUSTOMER__15B69B8FBD3D10F9",
                table: "CUSTOMER_POLICIES",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "EMPLOYEE",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__EMPLOYEE__15B69B8FBFD72589",
                table: "EMPLOYEE",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "HEALTH_HISTORY",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__HEALTH_H__15B69B8FAD12E3E0",
                table: "HEALTH_HISTORY",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "INSURANCE",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__INSURANC__15B69B8FDF297966",
                table: "INSURANCE",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "INSURANCE_PAYMENT",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__INSURANC__15B69B8F6483C5CF",
                table: "INSURANCE_PAYMENT",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "INSURANCE_REQUIRED",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__INSURANC__15B69B8F061E3A3B",
                table: "INSURANCE_REQUIRED",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "INSURANCE_TYPE",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__INSURANC__15B69B8F8ABB27D4",
                table: "INSURANCE_TYPE",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "POLICY_APPROVAL",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__POLICY_A__15B69B8FFD1FBDBA",
                table: "POLICY_APPROVAL",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "RESET_PASSWORD_REQUEST",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__RESET_PA__15B69B8F0CE555AB",
                table: "RESET_PASSWORD_REQUEST",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "ROLE",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__ROLE__15B69B8FAB73D4EE",
                table: "ROLE",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "SESSION",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__SESSION__15B69B8FE2E4485C",
                table: "SESSION",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_GUID",
                table: "STATUS",
                column: "GUID");

            migrationBuilder.CreateIndex(
                name: "UQ__STATUS__15B69B8F10330BE7",
                table: "STATUS",
                column: "GUID",
                unique: true,
                filter: "[GUID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BENEFIT");

            migrationBuilder.DropTable(
                name: "COMPENSATION");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "CUSTOMER_POLICIES");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "HEALTH_HISTORY");

            migrationBuilder.DropTable(
                name: "INSURANCE");

            migrationBuilder.DropTable(
                name: "INSURANCE_PAYMENT");

            migrationBuilder.DropTable(
                name: "INSURANCE_REQUIRED");

            migrationBuilder.DropTable(
                name: "INSURANCE_TYPE");

            migrationBuilder.DropTable(
                name: "POLICY_APPROVAL");

            migrationBuilder.DropTable(
                name: "RESET_PASSWORD_REQUEST");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "SESSION");

            migrationBuilder.DropTable(
                name: "STATUS");
        }
    }
}
