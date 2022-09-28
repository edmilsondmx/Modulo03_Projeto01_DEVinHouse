using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinCer.Infra.Migrations
{
    public partial class migrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    SUGGESTED_PRICE = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STATES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    INITIALS = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CITIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATE_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CITIES_STATES_STATE_ID",
                        column: x => x.STATE_ID,
                        principalTable: "STATES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SALE_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    BUYER_ID = table.Column<int>(type: "int", nullable: false),
                    SELLER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SALES_USERS_BUYER_ID",
                        column: x => x.BUYER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SALES_USERS_SELLER_ID",
                        column: x => x.SELLER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CITY = table.Column<int>(type: "int", nullable: false),
                    STREET = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    CEP = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    NUMBER = table.Column<int>(type: "int", nullable: false),
                    COMPLEMENT = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ADDRESS_CITIES_CITY",
                        column: x => x.CITY,
                        principalTable: "CITIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALECAR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AMOUNT = table.Column<int>(type: "int", nullable: true),
                    CAR_ID = table.Column<int>(type: "int", nullable: false),
                    SALE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALECAR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SALECAR_CARS_ID",
                        column: x => x.ID,
                        principalTable: "CARS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SALECAR_SALES_ID",
                        column: x => x.ID,
                        principalTable: "SALES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELIVERY_FORECAST = table.Column<DateTime>(type: "DATE", nullable: false),
                    ADDRESS_ID = table.Column<int>(type: "int", nullable: false),
                    SALE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DELIVERIES_ADDRESS_ADDRESS_ID",
                        column: x => x.ADDRESS_ID,
                        principalTable: "ADDRESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DELIVERIES_SALES_SALE_ID",
                        column: x => x.SALE_ID,
                        principalTable: "SALES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CARS",
                columns: new[] { "ID", "NAME", "SUGGESTED_PRICE" },
                values: new object[,]
                {
                    { 1, "Camaro Chevrolet", 60000m },
                    { 2, "Maverick Ford", 20000m },
                    { 3, "Astra Chevrolet", 30000m },
                    { 4, "Hilux Toyota", 20000m },
                    { 5, "Bravo Fiat", 20000m },
                    { 6, "BR800 Gurgel", 10000m },
                    { 7, "147 Fiat", 50000m },
                    { 8, "Del Rey Ford", 10000m },
                    { 9, "Mustang Ford", 70000m },
                    { 10, "Belina Ford", 20000m }
                });

            migrationBuilder.InsertData(
                table: "STATES",
                columns: new[] { "ID", "INITIALS", "NAME" },
                values: new object[,]
                {
                    { 1, "AC", "Acre" },
                    { 2, "AL", "Alagoas" },
                    { 3, "AP", "Amapá" },
                    { 4, "AM", "Amazonas" },
                    { 5, "BA", "Bahia" },
                    { 6, "CE", "Ceará" },
                    { 7, "DF", "Distrito Federal" },
                    { 8, "ES", "Espírito Santo" },
                    { 9, "GO", "Goiás" },
                    { 10, "MA", "Maranhão" },
                    { 11, "MT", "Mato Grosso" },
                    { 12, "MS", "Mato Grosso do Sul" },
                    { 13, "MG", "Minas Gerais" },
                    { 14, "PA", "Pará" },
                    { 15, "PB", "Paraíba" },
                    { 16, "PR", "Paraná" },
                    { 17, "PE", "Pernambuco" },
                    { 18, "PI", "Piauí" },
                    { 19, "RJ", "Rio de Janeiro" },
                    { 20, "RN", "Rio Grande do Norte" },
                    { 21, "RS", "Rio Grande do Sul" },
                    { 22, "RO", "Rondônia" },
                    { 23, "RR", "Roraima" },
                    { 24, "SC", "Santa Catarina" },
                    { 25, "SP", "São Paulo" },
                    { 26, "SE", "Sergipe" },
                    { 27, "TO", "Tocantins" }
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID", "BIRTH_DATE", "EMAIL", "NAME", "PASSWORD", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jose@email.com", "Jose", "123456opp78", 1 },
                    { 2, new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "andrea@email.com", "Andrea", "987dasd654321", 2 },
                    { 3, new DateTime(2005, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "adao@email.com", "Adao", "2589asd", 3 },
                    { 4, new DateTime(2001, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "monique@email.com", "Monique", "asd45uio", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_CITY",
                table: "ADDRESS",
                column: "CITY");

            migrationBuilder.CreateIndex(
                name: "IX_CITIES_STATE_ID",
                table: "CITIES",
                column: "STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERIES_ADDRESS_ID",
                table: "DELIVERIES",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERIES_SALE_ID",
                table: "DELIVERIES",
                column: "SALE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_BUYER_ID",
                table: "SALES",
                column: "BUYER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_SELLER_ID",
                table: "SALES",
                column: "SELLER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DELIVERIES");

            migrationBuilder.DropTable(
                name: "SALECAR");

            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "CARS");

            migrationBuilder.DropTable(
                name: "SALES");

            migrationBuilder.DropTable(
                name: "CITIES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "STATES");
        }
    }
}
