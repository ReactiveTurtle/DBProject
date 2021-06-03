using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForInvoice");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForManufacturer");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForProduct");

            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLoForSigner");

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Manufacturer_Name = table.Column<string>(nullable: false),
                    Manufacturer_Address = table.Column<string>(nullable: false),
                    Manufacturer_PhoneNumber = table.Column<string>(nullable: false),
                    Manufacturer_Email = table.Column<string>(nullable: true),
                    Manufacturer_ManagerFullname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Signer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Signer_Fullname = table.Column<string>(nullable: false),
                    Signer_Position = table.Column<string>(nullable: false),
                    Signer_Address = table.Column<string>(nullable: false),
                    Signer_PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Product_Name = table.Column<string>(nullable: false),
                    Product_Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Product_CurrencyType = table.Column<int>(nullable: false),
                    Product_ManufactureDateTime = table.Column<DateTime>(nullable: false),
                    Product_ExpirationDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    PreparationDate = table.Column<DateTime>(nullable: false),
                    SignerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Signer_SignerId",
                        column: x => x.SignerId,
                        principalTable: "Signer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInInvoice_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInInvoice_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SignerId",
                table: "Invoice",
                column: "SignerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerId",
                table: "Product",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInInvoice_InvoiceId",
                table: "ProductInInvoice",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInInvoice_ProductId",
                table: "ProductInInvoice",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInInvoice");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Signer");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForInvoice");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForManufacturer");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForProduct");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLoForSigner");
        }
    }
}
