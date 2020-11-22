using Microsoft.EntityFrameworkCore.Migrations;

namespace KariyerNetBackendTestCase.DataAccess.Migrations.MsSql
{
    public partial class JobApplications_relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCvId",
                table: "Users",
                column: "UserCvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCv_UserCvId",
                table: "Users",
                column: "UserCvId",
                principalTable: "UserCv",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCv_UserCvId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCvId",
                table: "Users");
        }
    }
}
