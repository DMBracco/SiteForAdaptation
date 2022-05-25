using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class ew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "MemoForManagers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MemoForManagers_CompanyId",
                table: "MemoForManagers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemoForManagers_Companies_CompanyId",
                table: "MemoForManagers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemoForManagers_Companies_CompanyId",
                table: "MemoForManagers");

            migrationBuilder.DropIndex(
                name: "IX_MemoForManagers_CompanyId",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "MemoForManagers");
        }
    }
}
