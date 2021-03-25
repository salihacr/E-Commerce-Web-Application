using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 20, 56, 9, 0, DateTimeKind.Local).AddTicks(4977), "Telefon" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 20, 56, 9, 0, DateTimeKind.Local).AddTicks(6174), "Bilgisayar" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 20, 56, 9, 0, DateTimeKind.Local).AddTicks(6202), "Tv, Ev Elektroniği" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "IsActive", "Name" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 3, 25, 20, 56, 9, 0, DateTimeKind.Local).AddTicks(6216), null, null, false, "Ev, Mutfak" },
                    { 4, new DateTime(2021, 3, 25, 20, 56, 9, 0, DateTimeKind.Local).AddTicks(6205), null, null, false, "Bilgisayar Parçaları" },
                    { 6, new DateTime(2021, 3, 25, 20, 56, 9, 0, DateTimeKind.Local).AddTicks(6212), null, null, false, "Aksesuar" },
                    { 5, new DateTime(2021, 3, 25, 20, 56, 9, 0, DateTimeKind.Local).AddTicks(6207), null, null, false, "Foto, Kamera" },
                    { 7, new DateTime(2021, 3, 25, 20, 56, 9, 0, DateTimeKind.Local).AddTicks(6214), null, null, false, "Oyun, Hobi" }
                });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreationDate", "Name" },
                values: new object[] { "#f9f6ef", new DateTime(2021, 3, 25, 20, 56, 8, 995, DateTimeKind.Local).AddTicks(7880), "Beyaz" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "CreationDate", "Name" },
                values: new object[] { "#202020", new DateTime(2021, 3, 25, 20, 56, 8, 997, DateTimeKind.Local).AddTicks(479), "Siyah" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "CreationDate", "Name" },
                values: new object[] { "#ba0c2f", new DateTime(2021, 3, 25, 20, 56, 8, 997, DateTimeKind.Local).AddTicks(529), "Kırmızı" });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Code", "CreationDate", "DateOfDelete", "DateOfUpdate", "IsActive", "Name", "ProductId" },
                values: new object[,]
                {
                    { 4, "#FECB2E", new DateTime(2021, 3, 25, 20, 56, 8, 997, DateTimeKind.Local).AddTicks(533), null, null, false, "Sarı", null },
                    { 5, "#147EFB", new DateTime(2021, 3, 25, 20, 56, 8, 997, DateTimeKind.Local).AddTicks(535), null, null, false, "Mavi", null },
                    { 6, "#53D769", new DateTime(2021, 3, 25, 20, 56, 8, 997, DateTimeKind.Local).AddTicks(541), null, null, false, "Yeşil", null }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 20, 56, 8, 999, DateTimeKind.Local).AddTicks(5301), "aciklama 1", "Ürün 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 20, 56, 8, 999, DateTimeKind.Local).AddTicks(9138), "aciklama 2", "Ürün 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 20, 56, 8, 999, DateTimeKind.Local).AddTicks(9351), "aciklama 3", "Ürün 3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2021, 3, 25, 20, 56, 8, 999, DateTimeKind.Local).AddTicks(9357), "aciklama 4", "Ürün 4", 14.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 20, 56, 8, 999, DateTimeKind.Local).AddTicks(9361), "aciklama 5", "Ürün 5" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "Description", "Discount", "IsActive", "IsHome", "MainImage", "Name", "Price", "Url" },
                values: new object[] { 6, new DateTime(2021, 3, 25, 20, 56, 8, 999, DateTimeKind.Local).AddTicks(9370), null, null, "aciklama 6", null, false, true, "none", "Ürün 6", 16.0, "product6" });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(6178), "Category1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(7342), "Category2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(7368), "Category3" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreationDate", "Name" },
                values: new object[] { "#111111", new DateTime(2021, 3, 25, 16, 8, 9, 373, DateTimeKind.Local).AddTicks(1189), "Black" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "CreationDate", "Name" },
                values: new object[] { "#ffffff", new DateTime(2021, 3, 25, 16, 8, 9, 374, DateTimeKind.Local).AddTicks(3518), "White" });

            migrationBuilder.UpdateData(
                table: "Color",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "CreationDate", "Name" },
                values: new object[] { "#test", new DateTime(2021, 3, 25, 16, 8, 9, 374, DateTimeKind.Local).AddTicks(3577), "Test" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 16, 8, 9, 376, DateTimeKind.Local).AddTicks(7769), "test desc1", "Product2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(1477), "test desc2", "Product2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(1547), "test desc3", "Product3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(1552), "test desc4", "Product3", 13.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Description", "Name" },
                values: new object[] { new DateTime(2021, 3, 25, 16, 8, 9, 377, DateTimeKind.Local).AddTicks(1555), "test desc5", "Product5" });
        }
    }
}
