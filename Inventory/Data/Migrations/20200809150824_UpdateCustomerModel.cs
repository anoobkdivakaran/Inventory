using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations
{
    public partial class UpdateCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
