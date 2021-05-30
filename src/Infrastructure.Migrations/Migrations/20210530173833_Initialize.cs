using System;
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
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    PreparationDate = table.Column<DateTime>(nullable: false),
                    Signer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
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
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Product_Manufacturer = table.Column<string>(nullable: false),
                    Product_Name = table.Column<string>(nullable: false),
                    Product_Price = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Product_CurrencyType = table.Column<int>(nullable: false),
                    Product_ManufactureDateTime = table.Column<DateTime>(nullable: false),
                    Product_ExpirationDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Signers",
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
                    table.PrimaryKey("PK_Signers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Signers");

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
