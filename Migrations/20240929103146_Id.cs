using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroBook.Migrations
{
    /// <inheritdoc />
    public partial class Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "Tables",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tables",
                newName: "TableId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservations",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");
        }
    }
}
