using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Numbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Darnell Brekke" },
                    { 2, "Lynda Lueilwitz" },
                    { 3, "Vickie Beier" },
                    { 4, "Kristy Kozey" },
                    { 5, "Emmett Howe" },
                    { 6, "Johnathan Pfeffer" },
                    { 7, "Jacob Crooks" },
                    { 8, "Irving Padberg" },
                    { 9, "Johnny Ryan" },
                    { 10, "Darnell Erdman" },
                    { 11, "Lillian Kemmer" },
                    { 12, "Carol Muller" },
                    { 13, "Lawrence Bahringer" },
                    { 14, "Amanda Roberts" },
                    { 15, "Fernando Murray" },
                    { 16, "Deanna Harvey" },
                    { 17, "Ida Nolan" },
                    { 18, "Nick Senger" },
                    { 19, "Jesus Johnson" },
                    { 20, "Alyssa Roob" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tasty Soft Shirt" },
                    { 2, "Licensed Soft Shoes" },
                    { 3, "Ergonomic Rubber Keyboard" },
                    { 4, "Practical Concrete Chips" },
                    { 5, "Handmade Wooden Chair" },
                    { 6, "Tasty Plastic Towels" },
                    { 7, "Intelligent Soft Computer" },
                    { 8, "Generic Concrete Salad" },
                    { 9, "Fantastic Plastic Towels" },
                    { 10, "Ergonomic Fresh Hat" },
                    { 11, "Rustic Soft Pants" },
                    { 12, "Ergonomic Fresh Ball" },
                    { 13, "Licensed Soft Computer" },
                    { 14, "Awesome Fresh Cheese" },
                    { 15, "Licensed Soft Salad" },
                    { 16, "Generic Concrete Gloves" },
                    { 17, "Rustic Granite Sausages" },
                    { 18, "Handmade Granite Fish" },
                    { 19, "Fantastic Metal Gloves" },
                    { 20, "Intelligent Cotton Shoes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_Number",
                table: "Numbers",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numbers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
