using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Com.Migrations
{
    public partial class changeProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MemoryDevices_MemoryDevicesMemoryDeviceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OperatingSytems_OperatingSytemsOSId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Processors_ProcessorsProcessorTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_StorageDevices_StorageDevicesStorageDeviceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_VGADevices_VGADevicesVGADeviceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MemoryDevicesMemoryDeviceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OperatingSytemsOSId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProcessorsProcessorTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StorageDevicesStorageDeviceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VGADevicesVGADeviceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MemoryDevicesMemoryDeviceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OperatingSytemsOSId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProcessorsProcessorTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StorageDevicesStorageDeviceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VGADevicesVGADeviceId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MemoryDeviceId",
                table: "Products",
                column: "MemoryDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OSId",
                table: "Products",
                column: "OSId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProcessorTypeId",
                table: "Products",
                column: "ProcessorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StorageDeviceId",
                table: "Products",
                column: "StorageDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VGADeviceId",
                table: "Products",
                column: "VGADeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MemoryDevices_MemoryDeviceId",
                table: "Products",
                column: "MemoryDeviceId",
                principalTable: "MemoryDevices",
                principalColumn: "MemoryDeviceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OperatingSytems_OSId",
                table: "Products",
                column: "OSId",
                principalTable: "OperatingSytems",
                principalColumn: "OSId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Processors_ProcessorTypeId",
                table: "Products",
                column: "ProcessorTypeId",
                principalTable: "Processors",
                principalColumn: "ProcessorTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StorageDevices_StorageDeviceId",
                table: "Products",
                column: "StorageDeviceId",
                principalTable: "StorageDevices",
                principalColumn: "StorageDeviceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VGADevices_VGADeviceId",
                table: "Products",
                column: "VGADeviceId",
                principalTable: "VGADevices",
                principalColumn: "VGADeviceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MemoryDevices_MemoryDeviceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OperatingSytems_OSId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Processors_ProcessorTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_StorageDevices_StorageDeviceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_VGADevices_VGADeviceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MemoryDeviceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OSId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProcessorTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StorageDeviceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VGADeviceId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "MemoryDevicesMemoryDeviceId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperatingSytemsOSId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessorsProcessorTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageDevicesStorageDeviceId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VGADevicesVGADeviceId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MemoryDevicesMemoryDeviceId",
                table: "Products",
                column: "MemoryDevicesMemoryDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OperatingSytemsOSId",
                table: "Products",
                column: "OperatingSytemsOSId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProcessorsProcessorTypeId",
                table: "Products",
                column: "ProcessorsProcessorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StorageDevicesStorageDeviceId",
                table: "Products",
                column: "StorageDevicesStorageDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VGADevicesVGADeviceId",
                table: "Products",
                column: "VGADevicesVGADeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MemoryDevices_MemoryDevicesMemoryDeviceId",
                table: "Products",
                column: "MemoryDevicesMemoryDeviceId",
                principalTable: "MemoryDevices",
                principalColumn: "MemoryDeviceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OperatingSytems_OperatingSytemsOSId",
                table: "Products",
                column: "OperatingSytemsOSId",
                principalTable: "OperatingSytems",
                principalColumn: "OSId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Processors_ProcessorsProcessorTypeId",
                table: "Products",
                column: "ProcessorsProcessorTypeId",
                principalTable: "Processors",
                principalColumn: "ProcessorTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StorageDevices_StorageDevicesStorageDeviceId",
                table: "Products",
                column: "StorageDevicesStorageDeviceId",
                principalTable: "StorageDevices",
                principalColumn: "StorageDeviceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VGADevices_VGADevicesVGADeviceId",
                table: "Products",
                column: "VGADevicesVGADeviceId",
                principalTable: "VGADevices",
                principalColumn: "VGADeviceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
