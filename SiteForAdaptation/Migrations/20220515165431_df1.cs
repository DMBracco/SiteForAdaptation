using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class df1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskFile_UserTaskParagraphs_UserTaskParagraphId",
                table: "UserTaskFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskFile",
                table: "UserTaskFile");

            migrationBuilder.RenameTable(
                name: "UserTaskFile",
                newName: "UserTaskFiles");

            migrationBuilder.RenameIndex(
                name: "IX_UserTaskFile_UserTaskParagraphId",
                table: "UserTaskFiles",
                newName: "IX_UserTaskFiles_UserTaskParagraphId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskFiles",
                table: "UserTaskFiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserTaskLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    UserTaskParagraphId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTaskLinks_UserTaskParagraphs_UserTaskParagraphId",
                        column: x => x.UserTaskParagraphId,
                        principalTable: "UserTaskParagraphs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskLinks_UserTaskParagraphId",
                table: "UserTaskLinks",
                column: "UserTaskParagraphId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskFiles_UserTaskParagraphs_UserTaskParagraphId",
                table: "UserTaskFiles",
                column: "UserTaskParagraphId",
                principalTable: "UserTaskParagraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskFiles_UserTaskParagraphs_UserTaskParagraphId",
                table: "UserTaskFiles");

            migrationBuilder.DropTable(
                name: "UserTaskLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTaskFiles",
                table: "UserTaskFiles");

            migrationBuilder.RenameTable(
                name: "UserTaskFiles",
                newName: "UserTaskFile");

            migrationBuilder.RenameIndex(
                name: "IX_UserTaskFiles_UserTaskParagraphId",
                table: "UserTaskFile",
                newName: "IX_UserTaskFile_UserTaskParagraphId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTaskFile",
                table: "UserTaskFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskFile_UserTaskParagraphs_UserTaskParagraphId",
                table: "UserTaskFile",
                column: "UserTaskParagraphId",
                principalTable: "UserTaskParagraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
