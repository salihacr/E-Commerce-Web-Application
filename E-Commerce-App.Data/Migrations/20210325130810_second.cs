using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(6178), null, null, false, "Category1" },
                    { 2, new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(7342), null, null, false, "Category2" },
                    { 3, new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(7368), null, null, false, "Category3" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Code", "CreationDate", "DateOfDelete", "DateOfUpdate", "IsActive", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, "#111111", new DateTime(2021, 3, 25, 16, 8, 9, 373, DateTimeKind.Local).AddTicks(1189), null, null, false, "Black", null },
                    { 2, "#ffffff", new DateTime(2021, 3, 25, 16, 8, 9, 374, DateTimeKind.Local).AddTicks(3518), null, null, false, "White", null },
                    { 3, "#test", new DateTime(2021, 3, 25, 16, 8, 9, 374, DateTimeKind.Local).AddTicks(3577), null, null, false, "Test", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "Description", "IsActive", "IsHome", "MainImage", "Name", "Price", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 25, 16, 8, 9, 376, DateTimeKind.Local).AddTicks(7769), null, null, "test desc1", false, true, "none", "Product2", 11.0, "product1" },
                    { 2, new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(1477), null, null, "test desc2", false, true, "none", "Product2", 12.0, "product2" },
                    { 3, new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(1547), null, null, "test desc3", false, true, "none", "Product3", 13.0, "product3" },
                    { 4, new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(1552), null, null, "test desc4", false, true, "none", "Product3", 13.0, "product4" },
                    { 5, new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(1555), null, null, "test desc5", false, true, "none", "Product5", 15.0, "product5" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
