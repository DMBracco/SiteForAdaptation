using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class ew4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemoForManagers_CompanyId",
                table: "MemoForManagers");

            migrationBuilder.CreateIndex(
                name: "IX_MemoForManagers_CompanyId",
                table: "MemoForManagers",
                column: "CompanyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemoForManagers_CompanyId",
                table: "MemoForManagers");

            migrationBuilder.CreateIndex(
                name: "IX_MemoForManagers_CompanyId",
                table: "MemoForManagers",
                column: "CompanyId");
        }
    }
}
