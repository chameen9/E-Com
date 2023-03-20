using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Com.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserTypes_UserTypesTypeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserTypesTypeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserTypesTypeId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeId",
                table: "User",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserTypes_TypeId",
                table: "User",
                column: "TypeId",
                principalTable: "UserTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserTypes_TypeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TypeId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserTypesTypeId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypesTypeId",
                table: "User",
                column: "UserTypesTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserTypes_UserTypesTypeId",
                table: "User",
                column: "UserTypesTypeId",
                principalTable: "UserTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
