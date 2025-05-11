using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductInitDbV9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreationDateTimeShamsi",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificationDateTimeShamsi",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreationDateTimeShamsi",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificationDateTimeShamsi",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreationDateTimeShamsi",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificationDateTimeShamsi",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDateTimeShamsi",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModificationDateTimeShamsi",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationDateTimeShamsi",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModificationDateTimeShamsi",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreationDateTimeShamsi",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModificationDateTimeShamsi",
                table: "Brands");
        }
    }
}
