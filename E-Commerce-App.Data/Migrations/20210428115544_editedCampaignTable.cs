using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class editedCampaignTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Campaigns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 55, 43, 965, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 55, 43, 966, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 55, 43, 967, DateTimeKind.Local).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 55, 43, 967, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 55, 43, 967, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 55, 43, 967, DateTimeKind.Local).AddTicks(73));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Campaigns");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 2, 50, 360, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 2, 50, 362, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 2, 50, 362, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 2, 50, 362, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 2, 50, 362, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreationDate",
                value: new DateTime(2021, 4, 28, 14, 2, 50, 362, DateTimeKind.Local).AddTicks(1554));
        }
    }
}
