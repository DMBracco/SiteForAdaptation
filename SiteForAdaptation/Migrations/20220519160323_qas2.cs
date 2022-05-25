using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class qas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoryItems");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "StoryMaps");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "StoryMaps");

            migrationBuilder.AddColumn<string>(
                name: "Subtitle_1",
                table: "StoryMaps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle_2",
                table: "StoryMaps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tittle",
                table: "StoryMaps",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtitle_1",
                table: "StoryMaps");

            migrationBuilder.DropColumn(
                name: "Subtitle_2",
                table: "StoryMaps");

            migrationBuilder.DropColumn(
                name: "Tittle",
                table: "StoryMaps");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "StoryMaps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "StoryMaps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryMapId = table.Column<int>(type: "int", nullable: false),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryItems_StoryMaps_StoryMapId",
                        column: x => x.StoryMapId,
                        principalTable: "StoryMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoryItems_StoryMapId",
                table: "StoryItems",
                column: "StoryMapId");
        }
    }
}
