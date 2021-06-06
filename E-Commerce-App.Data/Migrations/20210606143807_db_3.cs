using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class db_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasComment",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "ImageAltTag", "ImagePath", "IsActive", "IsHome", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 6, 17, 38, 6, 342, DateTimeKind.Local).AddTicks(5858), null, null, "iphone kampanya", "/images/iphone-kampanya.png", false, true, null },
                    { 2, new DateTime(2021, 6, 6, 17, 38, 6, 342, DateTimeKind.Local).AddTicks(5991), null, null, "samsung tv kampanya", "/images/samsung-tv-kampanya.png", false, true, null },
                    { 3, new DateTime(2021, 6, 6, 17, 38, 6, 342, DateTimeKind.Local).AddTicks(5995), null, null, "pc kampanya", "/images/pc-kampanya.png", false, true, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 341, DateTimeKind.Local).AddTicks(7805), true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 341, DateTimeKind.Local).AddTicks(7894), true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 341, DateTimeKind.Local).AddTicks(7898), true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 341, DateTimeKind.Local).AddTicks(7900), true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 341, DateTimeKind.Local).AddTicks(7902), true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 341, DateTimeKind.Local).AddTicks(7908), true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 341, DateTimeKind.Local).AddTicks(7910), true });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 341, DateTimeKind.Local).AddTicks(7912), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 338, DateTimeKind.Local).AddTicks(8265), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 340, DateTimeKind.Local).AddTicks(6759), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 340, DateTimeKind.Local).AddTicks(6912), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 340, DateTimeKind.Local).AddTicks(6918), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 340, DateTimeKind.Local).AddTicks(6921), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 6, 6, 17, 38, 6, 340, DateTimeKind.Local).AddTicks(6932), true });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "HasComment",
                table: "OrderItems");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 204, DateTimeKind.Local).AddTicks(7731), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 204, DateTimeKind.Local).AddTicks(7818), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 204, DateTimeKind.Local).AddTicks(7822), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 204, DateTimeKind.Local).AddTicks(7824), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 204, DateTimeKind.Local).AddTicks(7826), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 204, DateTimeKind.Local).AddTicks(7832), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 204, DateTimeKind.Local).AddTicks(7834), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 204, DateTimeKind.Local).AddTicks(7836), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 201, DateTimeKind.Local).AddTicks(9147), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 203, DateTimeKind.Local).AddTicks(7324), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 203, DateTimeKind.Local).AddTicks(7439), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 203, DateTimeKind.Local).AddTicks(7444), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 203, DateTimeKind.Local).AddTicks(7446), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "CreationDate", "IsActive" },
                values: new object[] { new DateTime(2021, 5, 27, 17, 54, 23, 203, DateTimeKind.Local).AddTicks(7455), false });
        }
    }
}
