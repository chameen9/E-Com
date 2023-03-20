using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Com.Migrations
{
    public partial class ChangeProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OperatingSytems_OperatingSytemsOSId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OperatingSytemsOSId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OperatingSytemsOSId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OSId",
                table: "Products",
                column: "OSId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OperatingSytems_OSId",
                table: "Products",
                column: "OSId",
                principalTable: "OperatingSytems",
                principalColumn: "OSId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OperatingSytems_OSId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OSId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "OperatingSytemsOSId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OperatingSytemsOSId",
                table: "Products",
                column: "OperatingSytemsOSId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OperatingSytems_OperatingSytemsOSId",
                table: "Products",
                column: "OperatingSytemsOSId",
                principalTable: "OperatingSytems",
                principalColumn: "OSId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
