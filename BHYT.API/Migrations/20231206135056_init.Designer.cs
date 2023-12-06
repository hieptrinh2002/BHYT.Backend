﻿// <auto-generated />
using System;
using BHYT.API.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BHYT.API.Migrations
{
    [DbContext(typeof(BHYTDbContext))]
    [Migration("20231206135056_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BHYT.API.Models.DbModels.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benefits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Coverage for medical expenses",
                            Guid = new Guid("698e5c48-6fda-4715-9b72-61d8a657462c"),
                            Name = "Health Insurance"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Coverage in the event of death",
                            Guid = new Guid("a2300e98-53cb-45c8-ada7-5193802fa50c"),
                            Name = "Life Insurance"
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.Compensation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PolicyId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Compensations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1000.5,
                            Date = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2629),
                            EmployeeId = 1,
                            Guid = new Guid("17a41d93-b2d9-4c8c-87dc-6b4d5b72b0b2"),
                            Note = "Bonus payment",
                            PolicyId = 1,
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Amount = 750.25,
                            Date = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2651),
                            EmployeeId = 2,
                            Guid = new Guid("892a74de-10b4-4ead-8416-cc0dd6db88f3"),
                            Note = "Incentive payment",
                            PolicyId = 2,
                            Status = true
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("Sex")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Bank = "ABC Bank",
                            BankNumber = "1234567890",
                            Birthday = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user1@example.com",
                            Fullname = "John Doe",
                            Guid = new Guid("83085ca8-163e-4a41-a013-1d6a9796be0b"),
                            Password = "password1",
                            Phone = "1234567890",
                            RoleId = 1,
                            Sex = 1,
                            StatusId = 1,
                            Username = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            Bank = "XYZ Bank",
                            BankNumber = "0987654321",
                            Birthday = new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user2@example.com",
                            Fullname = "Jane Smith",
                            Guid = new Guid("c4da4e81-0e55-46ee-b58e-0f95204c8929"),
                            Password = "password2",
                            Phone = "9876543210",
                            RoleId = 2,
                            Sex = 0,
                            StatusId = 1,
                            Username = "user2"
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.CustomerPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BenefitId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double?>("DeductibleAmount")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LatestUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("PaymentOption")
                        .HasColumnType("bit");

                    b.Property<double?>("PremiumAmount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CustomerPolicies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BenefitId = 1,
                            Company = "ABC Insurance",
                            CoverageType = "Comprehensive",
                            CreatedDate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2700),
                            CustomerId = 1,
                            DeductibleAmount = 500.0,
                            Description = "Policy for car insurance",
                            EndDate = new DateTime(2024, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2701),
                            Guid = new Guid("bde6a876-d5b4-40d7-969a-71132c231aa0"),
                            InsuranceId = 1,
                            LatestUpdate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2709),
                            PaymentOption = true,
                            PremiumAmount = 1000.5,
                            StartDate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2699),
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            BenefitId = 2,
                            Company = "XYZ Insurance",
                            CoverageType = "Third Party",
                            CreatedDate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2713),
                            CustomerId = 2,
                            DeductibleAmount = 1000.0,
                            Description = "Policy for home insurance",
                            EndDate = new DateTime(2024, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2713),
                            Guid = new Guid("279b9080-f40e-4bf4-8185-06b75b2c7dfa"),
                            InsuranceId = 2,
                            LatestUpdate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2719),
                            PaymentOption = false,
                            PremiumAmount = 1500.75,
                            StartDate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2712),
                            Status = true
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("Sex")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Birthday = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            Fullname = "John Doe",
                            Guid = new Guid("a0c1a5b2-3173-4709-9d41-01708d4643f1"),
                            Password = "password123",
                            Phone = "1234567890",
                            RoleId = 1,
                            Sex = 0,
                            StatusId = 1,
                            Username = "john_doe"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            Birthday = new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            Fullname = "Jane Smith",
                            Guid = new Guid("407663bd-4052-4e0e-9371-4ca248947d0d"),
                            Password = "password456",
                            Phone = "9876543210",
                            RoleId = 2,
                            Sex = 1,
                            StatusId = 1,
                            Username = "jane_smith"
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.HealthHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnostic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HospitalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HealthHistories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Condition = "health condition",
                            CreatedDate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2765),
                            CustomerId = 1,
                            Detail = "Patient's health history detail",
                            Diagnostic = "Diagnosis of the patient's condition",
                            Guid = new Guid("9781f0cc-b1f9-4c59-a6a9-43ab2c747bae"),
                            HospitalNumber = "123456789",
                            InsuranceId = 1,
                            Note = "Additional notes about the health history"
                        },
                        new
                        {
                            Id = 2,
                            Condition = "health condition",
                            CreatedDate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2772),
                            CustomerId = 2,
                            Detail = "Patient's health history detail",
                            Diagnostic = "Diagnosis of the patient's condition",
                            Guid = new Guid("63f69f8b-b490-4841-ae01-d7f8b361080e"),
                            HospitalNumber = "987654321",
                            InsuranceId = 2,
                            Note = "Additional notes about the health history"
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("EndAge")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InsuranceTypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("StartAge")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Insurances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Provides coverage for a specific term or period of time",
                            EndAge = (byte)65,
                            Guid = new Guid("ad80e263-10f0-4136-bf01-2a6f4e2ae0a2"),
                            InsuranceTypeId = "1",
                            Name = "Term Life Insurance",
                            StartAge = (byte)18
                        },
                        new
                        {
                            Id = 2,
                            Description = "Covers medical expenses for the entire family",
                            EndAge = (byte)99,
                            Guid = new Guid("87af9c70-3096-45dc-adf8-1fab6ae1a880"),
                            InsuranceTypeId = "2",
                            Name = "Family Health Insurance",
                            StartAge = (byte)0
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.InsurancePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PolicyId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InsurancePayments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1000.5,
                            CustomerId = 1,
                            Date = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2855),
                            Guid = new Guid("dd0a25f7-ac45-452a-951a-7425807a27a2"),
                            Note = "Payment for insurance policy",
                            PolicyId = 1,
                            Status = true,
                            Type = "Payment"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1500.75,
                            CustomerId = 2,
                            Date = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2862),
                            Guid = new Guid("ba1a2a94-1a43-47d9-a49f-cc3d8d4c7590"),
                            Note = "Payment for insurance policy",
                            PolicyId = 2,
                            Status = true,
                            Type = "Payment"
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.InsuranceRequired", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MedicalServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PolicyId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InsuranceRequireds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 500.5,
                            Date = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2888),
                            Guid = new Guid("e2cee227-0bde-4ad0-81e7-30cebc86bdbb"),
                            MedicalServiceName = "Medical Checkup",
                            Note = "Please schedule the appointment.",
                            PolicyId = 1,
                            ServiceDescription = "Required annual medical checkup",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1000.75,
                            Date = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2893),
                            Guid = new Guid("a4390601-4c76-4910-9214-bf91ae1b35cc"),
                            MedicalServiceName = "Diagnostic Tests",
                            Note = "Please complete the tests by the specified date.",
                            PolicyId = 2,
                            ServiceDescription = "Required diagnostic tests for policy renewal",
                            Status = 1
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.InsuranceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InsuranceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Provides coverage for the risk of life",
                            Guid = new Guid("26be99c4-6b5c-492e-af6e-27135be27032"),
                            Name = "Life Insurance"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Covers medical expenses and healthcare services",
                            Guid = new Guid("e4f75223-1eb5-42c8-a02c-d1bb0e01fdf6"),
                            Name = "Health Insurance"
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.PolicyApproval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PolicyId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PolicyApprovals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovalDate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2925),
                            EmployeeId = 1,
                            Guid = new Guid("34d0d383-2d53-4ed2-8418-a8c87307aedf"),
                            PolicyId = 1,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            ApprovalDate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2928),
                            EmployeeId = 2,
                            Guid = new Guid("c52c2b5b-655c-4719-a0f1-971e4402ce7a"),
                            PolicyId = 2,
                            StatusId = 2
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.ResetPasswordRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accountid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Requestdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Resetdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Resetrequestcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResetPasswordRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Accountid = "user1@example.com",
                            Guid = new Guid("0d6cbf79-1c33-4028-8c72-8be92508867a"),
                            Requestdate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2944),
                            Resetrequestcode = "ABC123"
                        },
                        new
                        {
                            Id = 2,
                            Accountid = "user2@example.com",
                            Guid = new Guid("fe93a51e-b6d5-497f-b32b-7bae13962b16"),
                            Requestdate = new DateTime(2023, 12, 6, 20, 50, 55, 906, DateTimeKind.Local).AddTicks(2947),
                            Resetrequestcode = "XYZ789"
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Guid = new Guid("d283c884-be45-4a31-88cf-19d138669205"),
                            Name = "employee"
                        },
                        new
                        {
                            Id = 2,
                            Guid = new Guid("35cb2e87-0ec2-43ec-b5eb-7ac703f26197"),
                            Name = "customer"
                        });
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Appversion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IsValid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LOginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionLastIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SessionLastRefresh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("BHYT.API.Models.DbModels.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Name")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Guid = new Guid("893527de-d105-434f-a3af-afc73138bf95"),
                            Name = true
                        },
                        new
                        {
                            Id = 2,
                            Guid = new Guid("e2df9c6b-c755-43b2-84c1-cc2624aa74c3"),
                            Name = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
