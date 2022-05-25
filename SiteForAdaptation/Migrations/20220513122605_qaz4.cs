using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class qaz4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_UserTypes_UserTypeId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeId",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "ContactItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContactItems_UserTypeId",
                table: "ContactItems",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactItems_UserTypes_UserTypeId",
                table: "ContactItems",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_UserTypes_UserTypeId",
                table: "Contacts",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactItems_UserTypes_UserTypeId",
                table: "ContactItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_UserTypes_UserTypeId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_ContactItems_UserTypeId",
                table: "ContactItems");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "ContactItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeId",
                table: "Contacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_UserTypes_UserTypeId",
                table: "Contacts",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
