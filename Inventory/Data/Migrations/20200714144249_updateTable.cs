using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsReceivedNote",
                columns: table => new
                {
                    GoodsReceivedNoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoodsReceivedNoteName = table.Column<string>(nullable: true),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    GRNDate = table.Column<DateTimeOffset>(nullable: false),
                    VendorDONumber = table.Column<string>(nullable: true),
                    VendorInvoiceNumber = table.Column<string>(nullable: true),
                    WarehouseId = table.Column<int>(nullable: false),
                    IsFullReceive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceivedNote", x => x.GoodsReceivedNoteId);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceName = table.Column<string>(nullable: true),
                    ShipmentId = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<DateTimeOffset>(nullable: false),
                    InvoiceDueDate = table.Column<DateTimeOffset>(nullable: false),
                    InvoiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceType",
                columns: table => new
                {
                    InvoiceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceTypeName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceType", x => x.InvoiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NumberSequence",
                columns: table => new
                {
                    NumberSequenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberSequenceName = table.Column<string>(nullable: false),
                    Module = table.Column<string>(nullable: false),
                    Prefix = table.Column<string>(nullable: false),
                    LastNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSequence", x => x.NumberSequenceId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentVoucher",
                columns: table => new
                {
                    PaymentvoucherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentVoucherName = table.Column<string>(nullable: true),
                    BillId = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    PaymentAmount = table.Column<double>(nullable: false),
                    CashBankId = table.Column<int>(nullable: false),
                    IsFullPayment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentVoucher", x => x.PaymentvoucherId);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesOrderName = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(nullable: false),
                    DeliveryDate = table.Column<DateTimeOffset>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    CustomerRefNumber = table.Column<string>(nullable: true),
                    SalesTypeId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    Freight = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.SalesOrderId);
                });

            migrationBuilder.CreateTable(
                name: "SalesType",
                columns: table => new
                {
                    SalesTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesTypeName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesType", x => x.SalesTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShipmentName = table.Column<string>(nullable: true),
                    SalesOrderId = table.Column<int>(nullable: false),
                    ShipmentDate = table.Column<DateTimeOffset>(nullable: false),
                    ShipmentTypeId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    IsFullShipment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.ShipmentId);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderLine",
                columns: table => new
                {
                    SalesOrderLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesOrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    DiscountPercentage = table.Column<double>(nullable: false),
                    DiscountAmount = table.Column<double>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    TaxPercentage = table.Column<double>(nullable: false),
                    TaxAmount = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderLine", x => x.SalesOrderLineId);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_SalesOrderId",
                table: "SalesOrderLine",
                column: "SalesOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceivedNote");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceType");

            migrationBuilder.DropTable(
                name: "NumberSequence");

            migrationBuilder.DropTable(
                name: "PaymentVoucher");

            migrationBuilder.DropTable(
                name: "SalesOrderLine");

            migrationBuilder.DropTable(
                name: "SalesType");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "SalesOrder");
        }
    }
}
