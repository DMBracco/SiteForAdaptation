using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteForAdaptation.Migrations
{
    public partial class qaz2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
