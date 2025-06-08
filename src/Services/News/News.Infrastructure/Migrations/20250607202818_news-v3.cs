using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newsv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_Articles_news_Comments_News_CommentId",
                table: "news_Articles");

            migrationBuilder.DropTable(
                name: "news_Comments");

            migrationBuilder.DropIndex(
                name: "IX_news_Articles_News_CommentId",
                table: "news_Articles");

            migrationBuilder.DropColumn(
                name: "News_CommentId",
                table: "news_Articles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "News_CommentId",
                table: "news_Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "news_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsArticleID = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_news_Comments_news_Articles_NewsArticleID",
                        column: x => x.NewsArticleID,
                        principalTable: "news_Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_Articles_News_CommentId",
                table: "news_Articles",
                column: "News_CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_news_Comments_NewsArticleID",
                table: "news_Comments",
                column: "NewsArticleID");

            migrationBuilder.AddForeignKey(
                name: "FK_news_Articles_news_Comments_News_CommentId",
                table: "news_Articles",
                column: "News_CommentId",
                principalTable: "news_Comments",
                principalColumn: "Id");
        }
    }
}
