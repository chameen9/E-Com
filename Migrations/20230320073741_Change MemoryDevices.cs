using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Com.Migrations
{
    public partial class ChangeMemoryDevices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemoryCapacity",
                table: "MemoryDevices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemoryCapacity",
                table: "MemoryDevices");
        }
    }
}
