using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hiastHRApi.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DegreesAuthorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreesAuthorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeputationObjectives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeputationObjectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeputationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeputationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeputationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeputationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisabilityTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatusTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationGrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationQuarters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationQuarters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialImpacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialImpacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialIndicatorTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialIndicatorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForcedVacationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForcedVacationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthyStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laws",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryRanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitarySpecializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitarySpecializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModificationContractTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModificationContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurrencePartnerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrencePartnerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgDepartments_OrgDepartments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "OrgDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ORDER = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionPercentages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionPercentages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelinquishmentReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelinquishmentReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RewardTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StartingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminationReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminationReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DocTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpDoc_DocTypes_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "DocTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PunishmentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialImpactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunishmentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PunishmentTypes_FinancialImpacts_FinancialImpactId",
                        column: x => x.FinancialImpactId,
                        principalTable: "FinancialImpacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobChangeReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobChangeReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobChangeReasons_ModificationContractTypes_ModificationContractTypeId",
                        column: x => x.ModificationContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_OrgDepartments_OrgDepartmentId",
                        column: x => x.OrgDepartmentId,
                        principalTable: "OrgDepartments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NationalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpPersonalInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FamilyBookDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    EmploymentStatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaritalStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RegistrationPlaceAndNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NationalNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CivilRegistry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FamilyBookNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPersonalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPersonalInfos_BloodGroups_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalTable: "BloodGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPersonalInfos_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPersonalInfos_EmploymentStatusTypes_EmploymentStatusTypeId",
                        column: x => x.EmploymentStatusTypeId,
                        principalTable: "EmploymentStatusTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPersonalInfos_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPersonalInfos_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPersonalInfos_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'1900-01-01'"),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalCardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpAppointmentStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfAppointmentDecision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfAppointmentVisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModifiedAppointmentVisaDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfInsuranceStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneralRegistryNumber = table.Column<int>(type: "int", nullable: false),
                    InsuranceSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineersSyndicateNumber = table.Column<int>(type: "int", nullable: false),
                    AppointmentContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LawId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthyStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisabilityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AppointmenContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AppointmentContractVisaNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModifiedAppointmentContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAppointmentStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_DisabilityTypes_DisabilityTypeId",
                        column: x => x.DisabilityTypeId,
                        principalTable: "DisabilityTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_HealthyStatuses_HealthyStatusId",
                        column: x => x.HealthyStatusId,
                        principalTable: "HealthyStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_InsuranceSystems_InsuranceSystemId",
                        column: x => x.InsuranceSystemId,
                        principalTable: "InsuranceSystems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_Laws_LawId",
                        column: x => x.LawId,
                        principalTable: "Laws",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_ModificationContractTypes_AppointmentContractTypeId",
                        column: x => x.AppointmentContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_ModificationContractTypes_ModificationContractTypeId",
                        column: x => x.ModificationContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAppointmentStatuses_StartingTypes_StartingTypeId",
                        column: x => x.StartingTypeId,
                        principalTable: "StartingTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedWork = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAssignments_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAssignments_ModificationContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpChildren",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OccurrenceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChildOrder = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OccurrenceContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpChildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpChildren_ChildStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ChildStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpChildren_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpChildren_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpDeputations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeputationDecisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutiveContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartAfterReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeputationObjectiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeputationStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeputationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeputationDecisionNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequiredSpecialization = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExecutiveContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AssignedEntity = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DeputationReason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpDeputations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpDeputations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpDeputations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpDeputations_DeputationObjectives_DeputationObjectiveId",
                        column: x => x.DeputationObjectiveId,
                        principalTable: "DeputationObjectives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpDeputations_DeputationStatuses_DeputationStatusId",
                        column: x => x.DeputationStatusId,
                        principalTable: "DeputationStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpDeputations_DeputationTypes_DeputationTypeId",
                        column: x => x.DeputationTypeId,
                        principalTable: "DeputationTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpDeputations_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpDeputations_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpEmploymentChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfAppointmentVisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    InsuranceSalary = table.Column<int>(type: "int", nullable: false),
                    JobChangeReasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Workplace = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VisaNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpEmploymentChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpEmploymentChanges_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpEmploymentChanges_JobChangeReasons_JobChangeReasonId",
                        column: x => x.JobChangeReasonId,
                        principalTable: "JobChangeReasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpEmploymentChanges_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpEmploymentChanges_ModificationContractTypes_ModificationContractTypeId",
                        column: x => x.ModificationContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpEmploymentStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpEmploymentStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpEmploymentStatuses_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpEmploymentStatuses_ModificationContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpEmploymentStatuses_StartingTypes_StartingTypeId",
                        column: x => x.StartingTypeId,
                        principalTable: "StartingTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpExperiences_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpExperiences_ExperienceTypes_ExperienceTypeId",
                        column: x => x.ExperienceTypeId,
                        principalTable: "ExperienceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayOnRecordCard = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpLanguages_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpLanguages_LanguageLevels_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpMilitaryServiceCohorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EndContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpMilitaryServiceCohorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpMilitaryServiceCohorts_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpMilitaryServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MilitaryRankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilitarySpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilitaryNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReserveNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CohortNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecruitmentBranch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecruitmentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpMilitaryServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpMilitaryServices_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpMilitaryServices_MilitaryRanks_MilitaryRankId",
                        column: x => x.MilitaryRankId,
                        principalTable: "MilitaryRanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpMilitaryServices_MilitarySpecializations_MilitarySpecializationId",
                        column: x => x.MilitarySpecializationId,
                        principalTable: "MilitarySpecializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpMilitaryServiceSuspensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuspensionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuspensionContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnToServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuspensionContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReturnContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpMilitaryServiceSuspensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpMilitaryServiceSuspensions_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpPartners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OccurrenceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartnerOrder = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerWorkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OccurrenceContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccurrenceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPartners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPartners_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPartners_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPartners_JobTitles_PartnerWorkId",
                        column: x => x.PartnerWorkId,
                        principalTable: "JobTitles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPartners_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPartners_OccurrencePartnerTypes_OccurrenceTypeId",
                        column: x => x.OccurrenceTypeId,
                        principalTable: "OccurrencePartnerTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpPerformanceEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromotionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluationGradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationQuarterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPerformanceEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPerformanceEvaluations_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPerformanceEvaluations_EvaluationGrades_EvaluationGradeId",
                        column: x => x.EvaluationGradeId,
                        principalTable: "EvaluationGrades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPerformanceEvaluations_EvaluationQuarters_EvaluationQuarterId",
                        column: x => x.EvaluationQuarterId,
                        principalTable: "EvaluationQuarters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpPromotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromotionDuration = table.Column<int>(type: "int", nullable: false),
                    EvaluationGradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PromotionPercentageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPromotions_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPromotions_EvaluationGrades_EvaluationGradeId",
                        column: x => x.EvaluationGradeId,
                        principalTable: "EvaluationGrades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPromotions_PromotionPercentages_PromotionPercentageId",
                        column: x => x.PromotionPercentageId,
                        principalTable: "PromotionPercentages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpPunishments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuingOrgDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    OrderOrgDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAppearingInRecordCard = table.Column<bool>(type: "bit", nullable: false),
                    ContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PunishmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PercentageOrAmount = table.Column<int>(type: "int", nullable: false),
                    IsPercentage = table.Column<bool>(type: "bit", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrderContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPunishments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPunishments_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPunishments_ModificationContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPunishments_OrgDepartments_IssuingOrgDepartmentId",
                        column: x => x.IssuingOrgDepartmentId,
                        principalTable: "OrgDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPunishments_OrgDepartments_OrderOrgDepartmentId",
                        column: x => x.OrderOrgDepartmentId,
                        principalTable: "OrgDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPunishments_PunishmentTypes_PunishmentTypeId",
                        column: x => x.PunishmentTypeId,
                        principalTable: "PunishmentTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpQualifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DegreeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquivalenceDegreeContractDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DegreesAuthorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubSpecialization = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EquivalenceContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpQualifications_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpQualifications_DegreesAuthorities_DegreesAuthorityId",
                        column: x => x.DegreesAuthorityId,
                        principalTable: "DegreesAuthorities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpQualifications_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpQualifications_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpQualifications_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpRelinquishments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelinquishmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelinquishmentReasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRelinquishments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpRelinquishments_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpRelinquishments_ModificationContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpRelinquishments_RelinquishmentReasons_RelinquishmentReasonId",
                        column: x => x.RelinquishmentReasonId,
                        principalTable: "RelinquishmentReasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpRewards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RewardTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    PercentageOrAmount = table.Column<int>(type: "int", nullable: false),
                    FinancialIndicatorTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpRewards_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpRewards_FinancialIndicatorTypes_FinancialIndicatorTypeId",
                        column: x => x.FinancialIndicatorTypeId,
                        principalTable: "FinancialIndicatorTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpRewards_ModificationContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpRewards_OrgDepartments_OrgDepartmentId",
                        column: x => x.OrgDepartmentId,
                        principalTable: "OrgDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpRewards_RewardTypes_RewardTypeId",
                        column: x => x.RewardTypeId,
                        principalTable: "RewardTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpTrainingCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayOnRecordCard = table.Column<bool>(type: "bit", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CourseSource = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpTrainingCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpTrainingCourses_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpTrainingCourses_ModificationContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpVacations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    VacationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacationYear = table.Column<int>(type: "int", nullable: false),
                    ContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAppearingInRecordCard = table.Column<bool>(type: "bit", nullable: false),
                    FinancialImpactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForcedVacationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsIncludedInServiceDuration = table.Column<bool>(type: "bit", nullable: false),
                    ModificationContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModificationContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpVacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpVacations_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpVacations_FinancialImpacts_FinancialImpactId",
                        column: x => x.FinancialImpactId,
                        principalTable: "FinancialImpacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpVacations_ForcedVacationTypes_ForcedVacationTypeId",
                        column: x => x.ForcedVacationTypeId,
                        principalTable: "ForcedVacationTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpVacations_ModificationContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpVacations_ModificationContractTypes_ModificationContractTypeId",
                        column: x => x.ModificationContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpVacations_VacationTypes_VacationTypeId",
                        column: x => x.VacationTypeId,
                        principalTable: "VacationTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpWorkInjuries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisabilityRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LumpSumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InjuryType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpWorkInjuries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpWorkInjuries_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpWorkPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRelinquishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpWorkPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpWorkPlaces_EmpPersonalInfos_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmpPersonalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpWorkPlaces_ModificationContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ModificationContractTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroups_Name",
                table: "BloodGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Name",
                table: "Branches",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_OrgDepartmentId",
                table: "Branches",
                column: "OrgDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name_IsDeleted",
                table: "Countries",
                columns: new[] { "Name", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_AppointmentContractTypeId",
                table: "EmpAppointmentStatuses",
                column: "AppointmentContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_DisabilityTypeId",
                table: "EmpAppointmentStatuses",
                column: "DisabilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_EmployeeId",
                table: "EmpAppointmentStatuses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_HealthyStatusId",
                table: "EmpAppointmentStatuses",
                column: "HealthyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_InsuranceSystemId",
                table: "EmpAppointmentStatuses",
                column: "InsuranceSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_JobCategoryId",
                table: "EmpAppointmentStatuses",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_LawId",
                table: "EmpAppointmentStatuses",
                column: "LawId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_ModificationContractTypeId",
                table: "EmpAppointmentStatuses",
                column: "ModificationContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAppointmentStatuses_StartingTypeId",
                table: "EmpAppointmentStatuses",
                column: "StartingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAssignments_ContractTypeId",
                table: "EmpAssignments",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAssignments_EmployeeId",
                table: "EmpAssignments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpChildren_EmployeeId",
                table: "EmpChildren",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpChildren_GenderId",
                table: "EmpChildren",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpChildren_StatusId",
                table: "EmpChildren",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDeputations_CityId",
                table: "EmpDeputations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDeputations_CountryId",
                table: "EmpDeputations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDeputations_DeputationObjectiveId",
                table: "EmpDeputations",
                column: "DeputationObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDeputations_DeputationStatusId",
                table: "EmpDeputations",
                column: "DeputationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDeputations_DeputationTypeId",
                table: "EmpDeputations",
                column: "DeputationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDeputations_EmployeeId",
                table: "EmpDeputations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDeputations_UniversityId",
                table: "EmpDeputations",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDocs_DocTypeId",
                table: "EmpDoc",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDocs_EmployeeId",
                table: "EmpDoc",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmploymentChanges_EmployeeId",
                table: "EmpEmploymentChanges",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmploymentChanges_JobChangeReasonId",
                table: "EmpEmploymentChanges",
                column: "JobChangeReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmploymentChanges_JobTitleId",
                table: "EmpEmploymentChanges",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmploymentChanges_ModificationContractTypeId",
                table: "EmpEmploymentChanges",
                column: "ModificationContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmploymentStatuses_ContractTypeId",
                table: "EmpEmploymentStatuses",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmploymentStatuses_EmployeeId",
                table: "EmpEmploymentStatuses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmploymentStatuses_StartingTypeId",
                table: "EmpEmploymentStatuses",
                column: "StartingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpExperiences_EmployeeId",
                table: "EmpExperiences",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpExperiences_ExperienceTypeId",
                table: "EmpExperiences",
                column: "ExperienceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpLanguages_EmployeeId",
                table: "EmpLanguages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpLanguages_LanguageId",
                table: "EmpLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpLanguages_LanguageLevelId",
                table: "EmpLanguages",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpMilitaryServiceCohorts_EmployeeId",
                table: "EmpMilitaryServiceCohorts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpMilitaryServices_EmployeeId",
                table: "EmpMilitaryServices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpMilitaryServices_MilitaryRankId",
                table: "EmpMilitaryServices",
                column: "MilitaryRankId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpMilitaryServices_MilitarySpecializationId",
                table: "EmpMilitaryServices",
                column: "MilitarySpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpMilitaryServiceSuspensions_EmployeeId",
                table: "EmpMilitaryServiceSuspensions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPartners_EmployeeId",
                table: "EmpPartners",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPartners_GenderId",
                table: "EmpPartners",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPartners_NationalityId",
                table: "EmpPartners",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPartners_OccurrenceTypeId",
                table: "EmpPartners",
                column: "OccurrenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPartners_PartnerWorkId",
                table: "EmpPartners",
                column: "PartnerWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPerformanceEvaluations_EmployeeId",
                table: "EmpPerformanceEvaluations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPerformanceEvaluations_EvaluationGradeId",
                table: "EmpPerformanceEvaluations",
                column: "EvaluationGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPerformanceEvaluations_EvaluationQuarterId",
                table: "EmpPerformanceEvaluations",
                column: "EvaluationQuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPersonalInfos_BloodGroupId",
                table: "EmpPersonalInfos",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPersonalInfos_CityId",
                table: "EmpPersonalInfos",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPersonalInfos_EmploymentStatusTypeId",
                table: "EmpPersonalInfos",
                column: "EmploymentStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPersonalInfos_GenderId",
                table: "EmpPersonalInfos",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPersonalInfos_MaritalStatusId",
                table: "EmpPersonalInfos",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPersonalInfos_NationalityId",
                table: "EmpPersonalInfos",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPromotions_EmployeeId",
                table: "EmpPromotions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPromotions_EvaluationGradeId",
                table: "EmpPromotions",
                column: "EvaluationGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPromotions_PromotionPercentageId",
                table: "EmpPromotions",
                column: "PromotionPercentageId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPunishments_ContractTypeId",
                table: "EmpPunishments",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPunishments_EmployeeId",
                table: "EmpPunishments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPunishments_IssuingOrgDepartmentId",
                table: "EmpPunishments",
                column: "IssuingOrgDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPunishments_OrderOrgDepartmentId",
                table: "EmpPunishments",
                column: "OrderOrgDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPunishments_PunishmentTypeId",
                table: "EmpPunishments",
                column: "PunishmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpQualifications_CountryId",
                table: "EmpQualifications",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpQualifications_DegreesAuthorityId",
                table: "EmpQualifications",
                column: "DegreesAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpQualifications_EmployeeId",
                table: "EmpQualifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpQualifications_QualificationId",
                table: "EmpQualifications",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpQualifications_SpecializationId",
                table: "EmpQualifications",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRelinquishments_ContractTypeId",
                table: "EmpRelinquishments",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRelinquishments_EmployeeId",
                table: "EmpRelinquishments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRelinquishments_RelinquishmentReasonId",
                table: "EmpRelinquishments",
                column: "RelinquishmentReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRewards_ContractTypeId",
                table: "EmpRewards",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRewards_EmployeeId",
                table: "EmpRewards",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRewards_FinancialIndicatorTypeId",
                table: "EmpRewards",
                column: "FinancialIndicatorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRewards_OrgDepartmentId",
                table: "EmpRewards",
                column: "OrgDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRewards_RewardTypeId",
                table: "EmpRewards",
                column: "RewardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpTrainingCourses_ContractTypeId",
                table: "EmpTrainingCourses",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpTrainingCourses_EmployeeId",
                table: "EmpTrainingCourses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpVacations_ContractTypeId",
                table: "EmpVacations",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpVacations_EmployeeId",
                table: "EmpVacations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpVacations_FinancialImpactId",
                table: "EmpVacations",
                column: "FinancialImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpVacations_ForcedVacationTypeId",
                table: "EmpVacations",
                column: "ForcedVacationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpVacations_ModificationContractTypeId",
                table: "EmpVacations",
                column: "ModificationContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpVacations_VacationTypeId",
                table: "EmpVacations",
                column: "VacationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpWorkInjuries_EmployeeId",
                table: "EmpWorkInjuries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpWorkPlaces_ContractTypeId",
                table: "EmpWorkPlaces",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpWorkPlaces_EmployeeId",
                table: "EmpWorkPlaces",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobChangeReasons_ModificationContractTypeId",
                table: "JobChangeReasons",
                column: "ModificationContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgDepartments_ParentId",
                table: "OrgDepartments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_NAME_IsDeleted",
                table: "Permissions",
                columns: new[] { "NAME", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_PunishmentTypes_FinancialImpactId",
                table: "PunishmentTypes",
                column: "FinancialImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId_PermissionId_IsDeleted",
                table: "RolePermissions",
                columns: new[] { "RoleId", "PermissionId", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name_IsDeleted",
                table: "Roles",
                columns: new[] { "Name", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_QualificationId",
                table: "Specializations",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartments_DepartmentId",
                table: "SubDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId_IsDeleted",
                table: "UserProfiles",
                columns: new[] { "UserId", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_IsDeleted",
                table: "Users",
                columns: new[] { "Email", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Mobile_IsDeleted",
                table: "Users",
                columns: new[] { "Mobile", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalNumber_IsDeleted",
                table: "Users",
                columns: new[] { "NationalNumber", "IsDeleted" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "EmpAppointmentStatuses");

            migrationBuilder.DropTable(
                name: "EmpAssignments");

            migrationBuilder.DropTable(
                name: "EmpChildren");

            migrationBuilder.DropTable(
                name: "EmpDeputations");

            migrationBuilder.DropTable(
                name: "EmpDoc");

            migrationBuilder.DropTable(
                name: "EmpEmploymentChanges");

            migrationBuilder.DropTable(
                name: "EmpEmploymentStatuses");

            migrationBuilder.DropTable(
                name: "EmpExperiences");

            migrationBuilder.DropTable(
                name: "EmpLanguages");

            migrationBuilder.DropTable(
                name: "EmpMilitaryServiceCohorts");

            migrationBuilder.DropTable(
                name: "EmpMilitaryServices");

            migrationBuilder.DropTable(
                name: "EmpMilitaryServiceSuspensions");

            migrationBuilder.DropTable(
                name: "EmpPartners");

            migrationBuilder.DropTable(
                name: "EmpPerformanceEvaluations");

            migrationBuilder.DropTable(
                name: "EmpPromotions");

            migrationBuilder.DropTable(
                name: "EmpPunishments");

            migrationBuilder.DropTable(
                name: "EmpQualifications");

            migrationBuilder.DropTable(
                name: "EmpRelinquishments");

            migrationBuilder.DropTable(
                name: "EmpRewards");

            migrationBuilder.DropTable(
                name: "EmpTrainingCourses");

            migrationBuilder.DropTable(
                name: "EmpVacations");

            migrationBuilder.DropTable(
                name: "EmpWorkInjuries");

            migrationBuilder.DropTable(
                name: "EmpWorkPlaces");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "SubDepartments");

            migrationBuilder.DropTable(
                name: "TerminationReasons");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "DisabilityTypes");

            migrationBuilder.DropTable(
                name: "HealthyStatuses");

            migrationBuilder.DropTable(
                name: "InsuranceSystems");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "Laws");

            migrationBuilder.DropTable(
                name: "ChildStatuses");

            migrationBuilder.DropTable(
                name: "DeputationObjectives");

            migrationBuilder.DropTable(
                name: "DeputationStatuses");

            migrationBuilder.DropTable(
                name: "DeputationTypes");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "DocTypes");

            migrationBuilder.DropTable(
                name: "JobChangeReasons");

            migrationBuilder.DropTable(
                name: "StartingTypes");

            migrationBuilder.DropTable(
                name: "ExperienceTypes");

            migrationBuilder.DropTable(
                name: "LanguageLevels");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MilitaryRanks");

            migrationBuilder.DropTable(
                name: "MilitarySpecializations");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "OccurrencePartnerTypes");

            migrationBuilder.DropTable(
                name: "EvaluationQuarters");

            migrationBuilder.DropTable(
                name: "EvaluationGrades");

            migrationBuilder.DropTable(
                name: "PromotionPercentages");

            migrationBuilder.DropTable(
                name: "PunishmentTypes");

            migrationBuilder.DropTable(
                name: "DegreesAuthorities");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "RelinquishmentReasons");

            migrationBuilder.DropTable(
                name: "FinancialIndicatorTypes");

            migrationBuilder.DropTable(
                name: "OrgDepartments");

            migrationBuilder.DropTable(
                name: "RewardTypes");

            migrationBuilder.DropTable(
                name: "ForcedVacationTypes");

            migrationBuilder.DropTable(
                name: "VacationTypes");

            migrationBuilder.DropTable(
                name: "EmpPersonalInfos");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ModificationContractTypes");

            migrationBuilder.DropTable(
                name: "FinancialImpacts");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "BloodGroups");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "EmploymentStatusTypes");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
