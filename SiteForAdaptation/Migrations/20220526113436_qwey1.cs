using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class qwey1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "UserStatistics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "UserStatistics");
        }
    }
}
