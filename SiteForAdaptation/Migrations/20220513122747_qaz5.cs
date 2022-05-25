using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class qaz5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_UserTypes_UserTypeId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserTypeId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserTypeId",
                table: "Contacts",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_UserTypes_UserTypeId",
                table: "Contacts",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
