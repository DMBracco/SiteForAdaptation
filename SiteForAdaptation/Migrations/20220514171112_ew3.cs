using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class ew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemoForManagerItems");

            migrationBuilder.DropColumn(
                name: "Subtittle",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Tittle",
                table: "MemoForManagers");

            migrationBuilder.AddColumn<string>(
                name: "Subtittle_1",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtittle_2",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtittle_3",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtittle_4",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtittle_5",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tittle_1",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tittle_2",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tittle_3",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tittle_4",
                table: "MemoForManagers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tittle_5",
                table: "MemoForManagers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtittle_1",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Subtittle_2",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Subtittle_3",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Subtittle_4",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Subtittle_5",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Tittle_1",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Tittle_2",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Tittle_3",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Tittle_4",
                table: "MemoForManagers");

            migrationBuilder.DropColumn(
                name: "Tittle_5",
                table: "MemoForManagers");

            migrationBuilder.AddColumn<string>(
                name: "Subtittle",
                table: "MemoForManagers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tittle",
                table: "MemoForManagers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemoForManagerItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemoForManagerId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoForManagerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemoForManagerItems_MemoForManagers_MemoForManagerId",
                        column: x => x.MemoForManagerId,
                        principalTable: "MemoForManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemoForManagerItems_MemoForManagerId",
                table: "MemoForManagerItems",
                column: "MemoForManagerId");
        }
    }
}
