using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Product_InitDBV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "StockQuantity",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name_FA",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name_EN",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name_AR",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Description_FA",
                table: "Products",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description_EN",
                table: "Products",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description_AR",
                table: "Products",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreationDateTime", "CreationDateTimeShamsi", "Description_AR", "Description_EN", "Description_FA", "ImageURL", "ModificationDateTime", "ModificationDateTimeShamsi", "Name_AR", "Name_EN", "Name_FA", "Price", "SKU", "StockQuantity", "Warranty" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 203, DateTimeKind.Utc).AddTicks(1354), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 203, DateTimeKind.Utc).AddTicks(1356), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 2, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(819), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(820), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 3, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(1365), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(1366), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 4, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(1768), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(1768), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 5, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(2166), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(2167), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 6, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(2566), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(2566), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 7, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(2969), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(2969), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 8, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(3427), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(3428), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 9, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(3877), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(3877), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 10, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(4280), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(4280), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 11, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(4707), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(4707), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 12, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(5120), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(5121), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 13, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(5556), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(5556), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 14, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(5957), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(5957), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 15, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(6366), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(6367), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 16, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(6763), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(6763), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 17, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(7156), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(7156), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 18, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(7555), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(7555), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 19, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(7986), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(7986), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 20, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(8388), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(8388), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 21, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(8783), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(8783), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 22, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(9182), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(9182), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null },
                    { 23, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(9574), "1404/02/29 07:54:22", null, null, null, null, new DateTime(2025, 5, 19, 7, 54, 22, 208, DateTimeKind.Utc).AddTicks(9574), "1404/02/29 07:54:22", null, null, null, 0m, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.AlterColumn<string>(
                name: "StockQuantity",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_FA",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_EN",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_AR",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_FA",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_EN",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description_AR",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "Active", "BannerUrl", "CreationDateTime", "CreationDateTimeShamsi", "Description", "IconUrl", "ModificationDateTime", "ModificationDateTimeShamsi", "Name_AR", "Name_EN", "Name_FA", "Permalink", "Priority", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, true, "", new DateTime(2025, 5, 19, 7, 26, 5, 580, DateTimeKind.Utc).AddTicks(784), "1404/02/29 07:26:05", "", "", new DateTime(2025, 5, 19, 7, 26, 5, 580, DateTimeKind.Utc).AddTicks(785), "1404/02/29 07:26:05", "جراحة العظام", "Orthopedics", "ارتوپدی", "", 1, "" },
                    { 2, true, "", new DateTime(2025, 5, 19, 7, 26, 5, 585, DateTimeKind.Utc).AddTicks(8166), "1404/02/29 07:26:05", "", "", new DateTime(2025, 5, 19, 7, 26, 5, 585, DateTimeKind.Utc).AddTicks(8167), "1404/02/29 07:26:05", "القلب والأوعية الدموية", "heart and blood vessels", "قلب و عروق", "", 1, "" },
                    { 3, true, "", new DateTime(2025, 5, 19, 7, 26, 5, 585, DateTimeKind.Utc).AddTicks(9115), "1404/02/29 07:26:05", "", "", new DateTime(2025, 5, 19, 7, 26, 5, 585, DateTimeKind.Utc).AddTicks(9115), "1404/02/29 07:26:05", "إدارة الألم", "Pain management", "مدیریت درد", "", 1, "" },
                    { 4, true, "", new DateTime(2025, 5, 19, 7, 26, 5, 585, DateTimeKind.Utc).AddTicks(9503), "1404/02/29 07:26:05", "", "", new DateTime(2025, 5, 19, 7, 26, 5, 585, DateTimeKind.Utc).AddTicks(9504), "1404/02/29 07:26:05", "جراحة المخ والأعصاب", "Neurosurgery", "جراحی اعصاب", "", 1, "" },
                    { 5, true, "", new DateTime(2025, 5, 19, 7, 26, 5, 585, DateTimeKind.Utc).AddTicks(9873), "1404/02/29 07:26:05", "", "", new DateTime(2025, 5, 19, 7, 26, 5, 585, DateTimeKind.Utc).AddTicks(9873), "1404/02/29 07:26:05", "التنظير", "Endoscopy", "آندروسکوپی", "", 1, "" }
                });
        }
    }
}
