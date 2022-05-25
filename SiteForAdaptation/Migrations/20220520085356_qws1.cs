using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class qws1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Openings");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Openings");

            migrationBuilder.CreateTable(
                name: "NavBars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_1 = table.Column<string>(nullable: true),
                    Link_1 = table.Column<string>(nullable: true),
                    Title_2 = table.Column<string>(nullable: true),
                    Link_2 = table.Column<string>(nullable: true),
                    Title_3 = table.Column<string>(nullable: true),
                    Link_3 = table.Column<string>(nullable: true),
                    Title_4 = table.Column<string>(nullable: true),
                    Link_4 = table.Column<string>(nullable: true),
                    Title_5 = table.Column<string>(nullable: true),
                    Link_5 = table.Column<string>(nullable: true),
                    UserTypeTittle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavBars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavBars");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Openings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Openings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
