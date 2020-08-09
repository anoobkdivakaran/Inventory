using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations
{
    public partial class UpdateCustomerModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerType_Customer_CustomerId",
                table: "CustomerType");

            migrationBuilder.DropIndex(
                name: "IX_CustomerType_CustomerId",
                table: "CustomerType");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerType");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerTypeId",
                table: "Customer",
                column: "CustomerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerType_CustomerTypeId",
                table: "Customer",
                column: "CustomerTypeId",
                principalTable: "CustomerType",
                principalColumn: "CustomerTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerType_CustomerTypeId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerTypeId",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerType",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerType_CustomerId",
                table: "CustomerType",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerType_Customer_CustomerId",
                table: "CustomerType",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
