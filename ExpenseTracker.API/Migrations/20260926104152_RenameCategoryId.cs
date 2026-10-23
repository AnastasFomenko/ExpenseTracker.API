using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpeneDate",
                table: "Expenses",
                newName: "ExpenseDate");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseDate",
                table: "Expenses",
                newName: "ExpeneDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "ID");
        }
    }
}
