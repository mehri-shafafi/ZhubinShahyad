using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class galleryinitdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_FA = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Title_AR = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDateTimeShamsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDateTimeShamsi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");
        }
    }
}
