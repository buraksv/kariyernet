using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KariyerNetBackendTestCase.DataAccess.Migrations.MsSql
{
    public partial class Mgr_InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SummaryInformation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CountryId = table.Column<short>(type: "smallint", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserCvId = table.Column<long>(type: "bigint", nullable: true),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyJobAdvertisements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    AdvertisementName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    CountryId = table.Column<short>(type: "smallint", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    ExpirationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyJobAdvertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyJobAdvertisements_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCvEducations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCvId = table.Column<long>(type: "bigint", nullable: false),
                    SchoolLevel = table.Column<short>(type: "smallint", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartYear = table.Column<short>(type: "smallint", nullable: false),
                    EndYear = table.Column<short>(type: "smallint", nullable: true),
                    IsAbandoned = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    GradeAverage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCvEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCvEducations_UserCv_UserCvId",
                        column: x => x.UserCvId,
                        principalTable: "UserCv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCvWorkingExperiences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCvId = table.Column<long>(type: "bigint", nullable: false),
                    CompanySector = table.Column<short>(type: "smallint", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WorkDetail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryId = table.Column<short>(type: "smallint", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCvWorkingExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCvWorkingExperiences_UserCv_UserCvId",
                        column: x => x.UserCvId,
                        principalTable: "UserCv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyJobAdvertisementId = table.Column<long>(type: "bigint", nullable: false),
                    ApplicationLetter = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsViewed = table.Column<bool>(type: "bit", nullable: false),
                    ViewTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_CompanyJobAdvertisements_CompanyJobAdvertisementId",
                        column: x => x.CompanyJobAdvertisementId,
                        principalTable: "CompanyJobAdvertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Companies_Mgr_NCIndex_22112020",
                table: "Companies",
                columns: new[] { "IsActive", "IsDeleted" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "CompanyJobAdvertisement_CompanyId_Mgr_NCIndex_22112020",
                table: "CompanyJobAdvertisements",
                column: "CompanyId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CompanyJobAdvertisementId",
                table: "JobApplications",
                column: "CompanyJobAdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "JobApplications_Mgr_IsViewed_NCIndex_22112020",
                table: "JobApplications",
                column: "IsViewed")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "JobApplications_Mgr_NCIndex_22112020",
                table: "JobApplications",
                column: "IsDeleted")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "UserCv_Mgr_NCIndex_22112020",
                table: "UserCv",
                columns: new[] { "CountryId", "CityId" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "UserCvEducations_Mgr_NCIndex_22112020",
                table: "UserCvEducations",
                column: "UserCvId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "UserCvWorkingExperience_Mgr_NCIndex_22112020",
                table: "UserCvWorkingExperiences",
                column: "UserCvId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "Users_Mgr_NCIndex_22112020",
                table: "Users",
                columns: new[] { "IsActive", "IsDeleted" })
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "UserCvEducations");

            migrationBuilder.DropTable(
                name: "UserCvWorkingExperiences");

            migrationBuilder.DropTable(
                name: "CompanyJobAdvertisements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserCv");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
