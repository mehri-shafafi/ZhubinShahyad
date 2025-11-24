using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dbv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCategoryID",
                table: "news_Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryID",
                table: "news_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
