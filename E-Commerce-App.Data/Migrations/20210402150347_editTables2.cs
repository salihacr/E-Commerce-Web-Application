using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class editTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 18, 3, 46, 322, DateTimeKind.Local).AddTicks(4063), 5.0, 1000.0, "lorem ipsum dat color..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 18, 3, 46, 324, DateTimeKind.Local).AddTicks(164), 5.0, 1200.0, "lorem ipsum dat color..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 18, 3, 46, 324, DateTimeKind.Local).AddTicks(292), 5.0, 1300.0, "lorem ipsum dat color..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 18, 3, 46, 324, DateTimeKind.Local).AddTicks(297), 5.0, 1400.0, "lorem ipsum dat color..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 18, 3, 46, 324, DateTimeKind.Local).AddTicks(300), 10.0, 1500.0, "lorem ipsum dat color..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 18, 3, 46, 324, DateTimeKind.Local).AddTicks(312), 20.0, 2000.0, "lorem ipsum dat color..." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 17, 50, 29, 163, DateTimeKind.Local).AddTicks(1973), null, 11.0, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 17, 50, 29, 164, DateTimeKind.Local).AddTicks(7326), null, 12.0, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 17, 50, 29, 164, DateTimeKind.Local).AddTicks(7426), null, 13.0, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 17, 50, 29, 164, DateTimeKind.Local).AddTicks(7432), null, 14.0, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 17, 50, 29, 164, DateTimeKind.Local).AddTicks(7435), null, 15.0, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "CreationDate", "Discount", "Price", "ShortDescription" },
                values: new object[] { new DateTime(2021, 4, 2, 17, 50, 29, 164, DateTimeKind.Local).AddTicks(7445), null, 16.0, null });
        }
    }
}
