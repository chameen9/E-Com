using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Com.Migrations
{
    public partial class NameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StrageDeviceType",
                table: "StorageDevices",
                newName: "StorageDeviceType");

            migrationBuilder.RenameColumn(
                name: "StrageDeviceCapacity",
                table: "StorageDevices",
                newName: "StorageDeviceCapacity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StorageDeviceType",
                table: "StorageDevices",
                newName: "StrageDeviceType");

            migrationBuilder.RenameColumn(
                name: "StorageDeviceCapacity",
                table: "StorageDevices",
                newName: "StrageDeviceCapacity");
        }
    }
}
