using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class qwer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTasks_CompanyId",
                table: "UserTasks");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_CompanyId",
                table: "UserTasks",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTasks_CompanyId",
                table: "UserTasks");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_CompanyId",
                table: "UserTasks",
                column: "CompanyId",
                unique: true);
        }
    }
}
