using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class db6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 727, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 727, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 727, DateTimeKind.Local).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 726, DateTimeKind.Local).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 726, DateTimeKind.Local).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 726, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 726, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 726, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 726, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 726, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 726, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 723, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 725, DateTimeKind.Local).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 725, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 725, DateTimeKind.Local).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 725, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 0, 3, 45, 725, DateTimeKind.Local).AddTicks(5305));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
