using Microsoft.EntityFrameworkCore.Migrations;

namespace InventroyMgtSystem.Migrations
{
    public partial class addUserIdToAllAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "SuppliedGood",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "InventoryItem",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_EmployeeId",
                table: "Warehouse",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuppliedGood_EmployeeId",
                table: "SuppliedGood",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_EmployeeId",
                table: "InventoryItem",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_EmployeeId",
                table: "Category",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_EmployeeId",
                table: "Category",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_AspNetUsers_EmployeeId",
                table: "InventoryItem",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SuppliedGood_AspNetUsers_EmployeeId",
                table: "SuppliedGood",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_AspNetUsers_EmployeeId",
                table: "Warehouse",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_EmployeeId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_AspNetUsers_EmployeeId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SuppliedGood_AspNetUsers_EmployeeId",
                table: "SuppliedGood");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_AspNetUsers_EmployeeId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_EmployeeId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_SuppliedGood_EmployeeId",
                table: "SuppliedGood");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_EmployeeId",
                table: "InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_Category_EmployeeId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SuppliedGood");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
