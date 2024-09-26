using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BistroBook.Migrations
{
    /// <inheritdoc />
    public partial class TestChangeMenuId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menus",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menus",
                newName: "MenuId");
        }
    }
}
