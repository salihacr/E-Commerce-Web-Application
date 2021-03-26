using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    OrderState = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Color_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 26, 14, 46, 49, 99, DateTimeKind.Local).AddTicks(6415), null, null, false, "Telefon" },
                    { 2, new DateTime(2021, 3, 26, 14, 46, 49, 99, DateTimeKind.Local).AddTicks(8278), null, null, false, "Bilgisayar" },
                    { 3, new DateTime(2021, 3, 26, 14, 46, 49, 99, DateTimeKind.Local).AddTicks(8324), null, null, false, "Tv, Ev Elektroniği" },
                    { 4, new DateTime(2021, 3, 26, 14, 46, 49, 99, DateTimeKind.Local).AddTicks(8328), null, null, false, "Bilgisayar Parçaları" },
                    { 5, new DateTime(2021, 3, 26, 14, 46, 49, 99, DateTimeKind.Local).AddTicks(8331), null, null, false, "Foto, Kamera" },
                    { 6, new DateTime(2021, 3, 26, 14, 46, 49, 99, DateTimeKind.Local).AddTicks(8341), null, null, false, "Aksesuar" },
                    { 7, new DateTime(2021, 3, 26, 14, 46, 49, 99, DateTimeKind.Local).AddTicks(8345), null, null, false, "Oyun, Hobi" },
                    { 8, new DateTime(2021, 3, 26, 14, 46, 49, 99, DateTimeKind.Local).AddTicks(8348), null, null, false, "Ev, Mutfak" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Code", "CreationDate", "DateOfDelete", "DateOfUpdate", "IsActive", "Name", "ProductId" },
                values: new object[,]
                {
                    { 6, "#53D769", new DateTime(2021, 3, 26, 14, 46, 49, 93, DateTimeKind.Local).AddTicks(7346), null, null, false, "Yeşil", null },
                    { 5, "#147EFB", new DateTime(2021, 3, 26, 14, 46, 49, 93, DateTimeKind.Local).AddTicks(7321), null, null, false, "Mavi", null },
                    { 4, "#FECB2E", new DateTime(2021, 3, 26, 14, 46, 49, 93, DateTimeKind.Local).AddTicks(7318), null, null, false, "Sarı", null },
                    { 2, "#202020", new DateTime(2021, 3, 26, 14, 46, 49, 93, DateTimeKind.Local).AddTicks(7222), null, null, false, "Siyah", null },
                    { 1, "#f9f6ef", new DateTime(2021, 3, 26, 14, 46, 49, 91, DateTimeKind.Local).AddTicks(7468), null, null, false, "Beyaz", null },
                    { 3, "#ba0c2f", new DateTime(2021, 3, 26, 14, 46, 49, 93, DateTimeKind.Local).AddTicks(7312), null, null, false, "Kırmızı", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "Description", "Discount", "IsActive", "IsHome", "MainImage", "Name", "Price", "Url" },
                values: new object[,]
                {
                    { "5", new DateTime(2021, 3, 26, 14, 46, 49, 98, DateTimeKind.Local).AddTicks(6400), null, null, "aciklama 5", null, false, true, "none", "Ürün 5", 15.0, "product5" },
                    { "1", new DateTime(2021, 3, 26, 14, 46, 49, 98, DateTimeKind.Local).AddTicks(364), null, null, "aciklama 1", null, false, true, "none", "Ürün 1", 11.0, "product1" },
                    { "2", new DateTime(2021, 3, 26, 14, 46, 49, 98, DateTimeKind.Local).AddTicks(6264), null, null, "aciklama 2", null, false, true, "none", "Ürün 2", 12.0, "product2" },
                    { "3", new DateTime(2021, 3, 26, 14, 46, 49, 98, DateTimeKind.Local).AddTicks(6385), null, null, "aciklama 3", null, false, true, "none", "Ürün 3", 13.0, "product3" },
                    { "4", new DateTime(2021, 3, 26, 14, 46, 49, 98, DateTimeKind.Local).AddTicks(6392), null, null, "aciklama 4", null, false, true, "none", "Ürün 4", 14.0, "product4" },
                    { "6", new DateTime(2021, 3, 26, 14, 46, 49, 98, DateTimeKind.Local).AddTicks(6417), null, null, "aciklama 6", null, false, true, "none", "Ürün 6", 16.0, "product6" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "1" },
                    { 3, "1" },
                    { 1, "2" },
                    { 2, "2" },
                    { 1, "3" },
                    { 2, "4" },
                    { 3, "5" },
                    { 4, "6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId1",
                table: "CartItems",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ProductId",
                table: "Color",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
