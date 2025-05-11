using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductInitDbV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Name_FA");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Description_FA");

            migrationBuilder.AddColumn<string>(
                name: "Description_AR",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_AR",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_EN",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_AR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name_AR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name_EN",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name_FA",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description_FA",
                table: "Products",
                newName: "Description");
        }
    }
}
