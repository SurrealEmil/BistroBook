using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BistroBook.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    TableNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    FK_CustomerId = table.Column<int>(type: "int", nullable: false),
                    FK_TableId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_FK_CustomerId",
                        column: x => x.FK_CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_FK_TableId",
                        column: x => x.FK_TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Jan.Eriksson@gmail.com", "Jan", "Eriksson", "0701234567" },
                    { 2, "Johan.Anderson@gmail.com", "Johan", "Anderson", "0702345678" },
                    { 3, "Anton.StenBerg@gmail.com", "Anton", "StenBerg", "0703456789" },
                    { 4, "Ida.Lundberg@gmail.com", "Ida", "Lundberg", "0704567890" },
                    { 5, "Julia.Levenhagen@gmail.com", "Julia", "Levenhagen", "0705678901" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Description", "DishName", "IsAvailable", "Price" },
                values: new object[,]
                {
                    { 1, "Tender meatballs served with creamy mashed potatoes, lingonberry sauce, and gravy.", "Swedish Meatballs", true, 120 },
                    { 2, "Fresh salmon fillet grilled to perfection, served with dill sauce and roasted vegetables.", "Grilled Salmon Fillet", true, 180 },
                    { 3, "Tagliatelle pasta tossed in a creamy mushroom sauce with a hint of garlic and Parmesan.", "Creamy Mushroom Pasta", true, 140 },
                    { 4, "Crisp chicken strips served on a bed of mixed greens, cherry tomatoes, cucumbers, and honey mustard dressing.", "Crispy Chicken Salad", true, 99 },
                    { 5, "A classic Swedish shrimp salad mixed with mayonnaise, dill, and lemon, served on toast.", "Shrimp Skagen", false, 115 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "SeatCount", "TableNumber" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 6, 2 },
                    { 3, 2, 3 },
                    { 4, 8, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "Date", "EndTime", "FK_CustomerId", "FK_TableId", "GuestCount", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), 1, 1, 2, new TimeSpan(0, 18, 0, 0, 0) },
                    { 2, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 0, 0, 0), 2, 2, 2, new TimeSpan(0, 20, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FK_CustomerId",
                table: "Reservations",
                column: "FK_CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FK_TableId",
                table: "Reservations",
                column: "FK_TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
