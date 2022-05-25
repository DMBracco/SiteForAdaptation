using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class rem1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTasks_UserTypeId",
                table: "UserTasks");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserTypeId",
                table: "UserTasks",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTasks_UserTypeId",
                table: "UserTasks");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserTypeId",
                table: "UserTasks",
                column: "UserTypeId",
                unique: true);
        }
    }
}
