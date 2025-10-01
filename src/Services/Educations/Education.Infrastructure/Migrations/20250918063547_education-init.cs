using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class educationinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trainingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_training_trainingCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "trainingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingId = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContentUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainingTranslations_training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_training_CategoryId",
                table: "training",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingTranslations_TrainingId",
                table: "trainingTranslations",
                column: "TrainingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trainingTranslations");

            migrationBuilder.DropTable(
                name: "training");

            migrationBuilder.DropTable(
                name: "trainingCategories");
        }
    }
}
