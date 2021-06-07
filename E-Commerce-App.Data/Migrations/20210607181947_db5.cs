using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class db5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 529, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 529, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 529, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 528, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 528, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 528, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 528, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 528, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 528, DateTimeKind.Local).AddTicks(2383));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 528, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 528, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 524, DateTimeKind.Local).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 527, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 527, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 527, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 527, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreationDate",
                value: new DateTime(2021, 6, 7, 21, 19, 46, 527, DateTimeKind.Local).AddTicks(600));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 672, DateTimeKind.Local).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 672, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 672, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 671, DateTimeKind.Local).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 671, DateTimeKind.Local).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 671, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 671, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 671, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 671, DateTimeKind.Local).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 671, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 671, DateTimeKind.Local).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 668, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 670, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 670, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 670, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 670, DateTimeKind.Local).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreationDate",
                value: new DateTime(2021, 6, 6, 19, 46, 51, 670, DateTimeKind.Local).AddTicks(7563));
        }
    }
}
