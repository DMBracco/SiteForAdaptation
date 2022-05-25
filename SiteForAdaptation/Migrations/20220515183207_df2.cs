using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class df2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskLinks_UserTaskParagraphs_UserTaskParagraphId",
                table: "UserTaskLinks");

            migrationBuilder.AlterColumn<int>(
                name: "UserTaskParagraphId",
                table: "UserTaskLinks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskLinks_UserTaskParagraphs_UserTaskParagraphId",
                table: "UserTaskLinks",
                column: "UserTaskParagraphId",
                principalTable: "UserTaskParagraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTaskLinks_UserTaskParagraphs_UserTaskParagraphId",
                table: "UserTaskLinks");

            migrationBuilder.AlterColumn<int>(
                name: "UserTaskParagraphId",
                table: "UserTaskLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserTaskLinks_UserTaskParagraphs_UserTaskParagraphId",
                table: "UserTaskLinks",
                column: "UserTaskParagraphId",
                principalTable: "UserTaskParagraphs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
