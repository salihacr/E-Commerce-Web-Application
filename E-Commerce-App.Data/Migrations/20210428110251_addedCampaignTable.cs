using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class addedCampaignTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAltTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreationDate",
                value: new DateTime(2021, 4, 12, 20, 47, 54, 987, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreationDate",
                value: new DateTime(2021, 4, 12, 20, 47, 54, 990, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreationDate",
                value: new DateTime(2021, 4, 12, 20, 47, 54, 990, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreationDate",
                value: new DateTime(2021, 4, 12, 20, 47, 54, 990, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreationDate",
                value: new DateTime(2021, 4, 12, 20, 47, 54, 990, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreationDate",
                value: new DateTime(2021, 4, 12, 20, 47, 54, 990, DateTimeKind.Local).AddTicks(2178));
        }
    }
}
