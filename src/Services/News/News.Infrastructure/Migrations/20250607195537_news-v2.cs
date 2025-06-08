using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newsv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_Comments_news_Articles_news_ArticleId",
                table: "news_Comments");

            migrationBuilder.DropIndex(
                name: "IX_news_Comments_news_ArticleId",
                table: "news_Comments");

            migrationBuilder.DropColumn(
                name: "news_ArticleId",
                table: "news_Comments");

            migrationBuilder.AddColumn<int>(
                name: "News_CommentId",
                table: "news_Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_news_Comments_NewsArticleID",
                table: "news_Comments",
                column: "NewsArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_news_Articles_News_CommentId",
                table: "news_Articles",
                column: "News_CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_news_Articles_news_Comments_News_CommentId",
                table: "news_Articles",
                column: "News_CommentId",
                principalTable: "news_Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_news_Comments_news_Articles_NewsArticleID",
                table: "news_Comments",
                column: "NewsArticleID",
                principalTable: "news_Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_Articles_news_Comments_News_CommentId",
                table: "news_Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_news_Comments_news_Articles_NewsArticleID",
                table: "news_Comments");

            migrationBuilder.DropIndex(
                name: "IX_news_Comments_NewsArticleID",
                table: "news_Comments");

            migrationBuilder.DropIndex(
                name: "IX_news_Articles_News_CommentId",
                table: "news_Articles");

            migrationBuilder.DropColumn(
                name: "News_CommentId",
                table: "news_Articles");

            migrationBuilder.AddColumn<int>(
                name: "news_ArticleId",
                table: "news_Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_news_Comments_news_ArticleId",
                table: "news_Comments",
                column: "news_ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_news_Comments_news_Articles_news_ArticleId",
                table: "news_Comments",
                column: "news_ArticleId",
                principalTable: "news_Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
