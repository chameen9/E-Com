using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Com.Migrations
{
    public partial class addFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserTypes_UserTypesTypeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserTypesTypeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserTypesTypeId",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "User",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
