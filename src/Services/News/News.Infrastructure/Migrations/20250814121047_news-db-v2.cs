using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newsdbv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "news_Articles",
                newName: "Title_FA");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "news_Articles",
                newName: "Summary_FA");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "news_Articles",
                newName: "Content_FA");

            migrationBuilder.AddColumn<string>(
                name: "Content_AR",
                table: "news_Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content_EN",
                table: "news_Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Summary_AR",
                table: "news_Articles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Summary_EN",
                table: "news_Articles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_AR",
                table: "news_Articles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_EN",
                table: "news_Articles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content_AR",
                table: "news_Articles");

            migrationBuilder.DropColumn(
                name: "Content_EN",
                table: "news_Articles");

            migrationBuilder.DropColumn(
                name: "Summary_AR",
                table: "news_Articles");

            migrationBuilder.DropColumn(
                name: "Summary_EN",
                table: "news_Articles");

            migrationBuilder.DropColumn(
                name: "Title_AR",
                table: "news_Articles");

            migrationBuilder.DropColumn(
                name: "Title_EN",
                table: "news_Articles");

            migrationBuilder.RenameColumn(
                name: "Title_FA",
                table: "news_Articles",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Summary_FA",
                table: "news_Articles",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "Content_FA",
                table: "news_Articles",
                newName: "Content");
        }
    }
}
