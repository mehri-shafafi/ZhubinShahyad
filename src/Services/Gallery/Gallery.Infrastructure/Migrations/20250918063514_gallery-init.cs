using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class galleryinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_FA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_AR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc_FA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc_AR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDateTimeShamsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDateTimeShamsi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesGallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CategoriesGalleryId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDateTimeShamsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDateTimeShamsi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gallery_CategoriesGallery_CategoriesGalleryId",
                        column: x => x.CategoriesGalleryId,
                        principalTable: "CategoriesGallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_CategoriesGalleryId",
                table: "Gallery",
                column: "CategoriesGalleryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "CategoriesGallery");
        }
    }
}
