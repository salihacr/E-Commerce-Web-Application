using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_App.Data.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAltTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

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
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMainCategory = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
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
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
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
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SelectedColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasComment = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColor", x => new { x.ProductId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_ProductColor_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColor_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelete = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, new DateTime(2021, 6, 14, 20, 43, 40, 397, DateTimeKind.Local).AddTicks(3201), null, null, "iphone kampanya", "iphone-kampanya.png", false, true, null },
                    { 2, new DateTime(2021, 6, 14, 20, 43, 40, 397, DateTimeKind.Local).AddTicks(3321), null, null, "samsung tv kampanya", "samsung-tv-kampanya.png", false, true, null },
                    { 3, new DateTime(2021, 6, 14, 20, 43, 40, 397, DateTimeKind.Local).AddTicks(3326), null, null, "pc kampanya", "pc-kampanya.png", false, true, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "IsActive", "IsMainCategory", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4891), null, null, true, false, "Telefon", "telefon" },
                    { 2, new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4986), null, null, true, false, "Bilgisayar", "bilgisayar" },
                    { 3, new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4990), null, null, true, false, "Tv, Ev Elektroniği", "tv-ev-elektronigi" },
                    { 4, new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4992), null, null, true, false, "Bilgisayar Parçaları", "bilgisayar-parcalari" },
                    { 5, new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(4994), null, null, true, false, "Foto, Kamera", "foto-kamera" },
                    { 6, new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(5000), null, null, true, false, "Aksesuar", "aksesuar" },
                    { 7, new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(5002), null, null, true, false, "Oyun, Hobi", "oyun-hobi" },
                    { 8, new DateTime(2021, 6, 14, 20, 43, 40, 396, DateTimeKind.Local).AddTicks(5004), null, null, true, false, "Ev, Mutfak", "ev-mutfak" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Code", "CreationDate", "DateOfDelete", "DateOfUpdate", "IsActive", "Name" },
                values: new object[,]
                {
                    { 6, "#53D769", null, null, null, false, "Yeşil" },
                    { 4, "#FECB2E", null, null, null, false, "Sarı" },
                    { 5, "#147EFB", null, null, null, false, "Mavi" },
                    { 2, "#202020", null, null, null, false, "Siyah" },
                    { 1, "#f9f6ef", null, null, null, false, "Beyaz" },
                    { 3, "#ba0c2f", null, null, null, false, "Kırmızı" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "Description", "Discount", "IsActive", "IsHome", "MainImage", "Name", "Price", "ShortDescription", "Url" },
                values: new object[,]
                {
                    { "18", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4429), null, null, "Asus Zenbook Laptop Pc", 1.0, true, true, "asus-zenbook.jpg", "Asus Zenbook Laptop", 12000.0, "lorem ipsum dat color...", "asus-zenbook" },
                    { "19", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4432), null, null, "Arçelik Buzdolabı", 5.0, true, true, "arcelik-buzdolabi.png", "Arçelik Buzdolabı", 4600.0, "lorem ipsum dat color...", "arcelik-buzdolabi" },
                    { "20", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4434), null, null, "Bosch Çamaşır Makinesi", null, true, true, "bosch-camasir-makinesi.jpg", "Bosch Çamaşır Makinesi", 3528.0, "lorem ipsum dat color...", "bosch-camasir-makinesi" },
                    { "21", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4437), null, null, "Canon EOS 750D", null, true, true, "canon-eos750d.jpg", "Canon EOS 750D", 6540.0, "lorem ipsum dat color...", "canon-eos750d" },
                    { "22", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4439), null, null, "Nikon D5600", 5.0, true, true, "nikon-d5600.jpg", "Nikon D5600", 5980.0, "lorem ipsum dat color...", "nikon-d5600" },
                    { "23", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4442), null, null, "LG Nanocell Tv", 10.0, true, true, "lg-nanocell-tv.jpg", "LG Nanocell Tv", 11000.0, "lorem ipsum dat color...", "lg-nanocell-tv" },
                    { "25", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4448), null, null, "Apple Watch SE", null, true, true, "apple-watch-se.png", "Apple Watch SE", 2550.0, "lorem ipsum dat color...", "apple-watch-se" },
                    { "26", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4451), null, null, "Xiaomi Mi Band", 12.0, true, true, "xioami-mi-band.jpg", "Xiaomi Mi Band", 600.0, "lorem ipsum dat color...", "xioami-mi-band" },
                    { "27", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4470), null, null, "Mouse Razer", null, true, true, "razer-mouse.jpg", "Mouse Razer", 150.0, "lorem ipsum dat color...", "razer-mouse" },
                    { "28", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4473), null, null, "Klavye Razer", 10.0, true, true, "razer-klavye.jpg", "Klavye Razer", 685.0, "lorem ipsum dat color...", "razer-klavye" },
                    { "29", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4476), null, null, "steelseries-kulaklık", 5.0, true, true, "steelseries-kulaklik.jpg", "steelseries-kulaklık", 975.0, "lorem ipsum dat color...", "steelseries-kulaklik" },
                    { "30", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4478), null, null, "air-pods", 5.0, true, true, "air-pods.jfif", "air-pods", 4000.0, "lorem ipsum dat color...", "air-pods" },
                    { "17", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4424), null, null, "Dell Laptop Pc İş İstasyonu", 8.0, true, true, "dell-is-istasyonu.jpg", "Dell Laptop Pc", 14500.0, "lorem ipsum dat color...", "dell-is-istasyonu" },
                    { "24", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4445), null, null, "Samsung 4K Curved Tv", 9.0, true, true, "samsung-curved-tv.png", "Samsung 4K Curved Tv", 12000.0, "lorem ipsum dat color...", "samsung-curved-tv" },
                    { "16", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4419), null, null, "Monster Game Notebook", 5.0, true, true, "monster-notebook.jpg", "Monster Notebook", 8560.0, "lorem ipsum dat color...", "monster-notebook" },
                    { "8", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4394), null, null, "Samsung Galaxy S10", 10.0, true, true, "samsung-galaxy-s10.jpg", "Samsung Galaxy S10", 6000.0, "lorem ipsum dat color...", "samsung-galaxy-s10" },
                    { "14", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4413), null, null, "Macbook Air || Apple", null, true, true, "macbook-air.jfif", "Macbook Air | Apple", 14000.0, "lorem ipsum dat color...", "macbook-air" },
                    { "13", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4410), null, null, "Macbook Pro 19 | Apple", null, true, true, "macbook-pro-19.jfif", "Macbook Pro 19 | Apple", 21000.0, "lorem ipsum dat color...", "macbook-pro-19" },
                    { "12", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4407), null, null, "Macbook Pro M1 | Apple", null, true, true, "macbook-pro-m1.jfif", "Macbook Pro M1 | Apple", 16000.0, "lorem ipsum dat color...", "macbook-pro-m1" },
                    { "11", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4404), null, null, "Xiaomi Redmi Note 8", 5.0, true, true, "xiaomi-redmi-note8.jpg", "Xiaomi Redmi Note 8", 2600.0, "lorem ipsum dat color...", "xiaomi-redmi-note8" },
                    { "10", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4402), null, null, "Samsung Galaxy A50", null, true, true, "samsung-galaxy-a50.jpg", "Samsung Galaxy A50", 4500.0, "lorem ipsum dat color...", "samsung-galaxy-a50" },
                    { "9", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4397), null, null, "Samsung Galaxy M20", 15.0, true, true, "samsung-galaxy-m20.jpg", "Samsung Galaxy M20", 4000.0, "lorem ipsum dat color...", "samsung-galaxy-m20" },
                    { "31", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4481), null, null, "Playstation 5", 7.0, true, true, "playstation5.jpg", "Playstation 5", 12000.0, "lorem ipsum dat color...", "playstation5" },
                    { "7", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4391), null, null, "Samsung Galaxy S21", 5.0, true, true, "samsung-galaxy-s21.jpg", "Samsung Galaxy S21", 9000.0, "lorem ipsum dat color...", "samsung-galaxy-s21" },
                    { "6", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4387), null, null, "Iphone 8 | Apple", 3.0, true, true, "iphone8.jpg", "Iphone 8 | Apple", 5800.0, "lorem ipsum dat color...", "iphone8-apple" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreationDate", "DateOfDelete", "DateOfUpdate", "Description", "Discount", "IsActive", "IsHome", "MainImage", "Name", "Price", "ShortDescription", "Url" },
                values: new object[,]
                {
                    { "5", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4378), null, null, "Iphone 8 Plus | Apple", null, true, true, "iphone8plus.jpg", "Iphone 8 Plus | Apple", 6758.0, "lorem ipsum dat color...", "iphone8plus-apple" },
                    { "4", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4375), null, null, "Iphone SE2 | Apple", null, true, true, "iphonese.jpg", "Iphone SE2 | Apple", 8500.0, "lorem ipsum dat color...", "iphonese2-apple" },
                    { "3", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4370), null, null, "Iphone 11 | Apple", null, true, true, "iphone11.jpg", "Iphone 11 | Apple", 10000.0, "lorem ipsum dat color...", "iphone11-apple" },
                    { "2", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4242), null, null, "Iphone 12 | Apple", 2.0, true, true, "iphone12.png", "Iphone 12 | Apple", 12000.0, "lorem ipsum dat color...", "iphone12-apple" },
                    { "1", new DateTime(2021, 6, 14, 20, 43, 40, 393, DateTimeKind.Local).AddTicks(5773), null, null, "Xiaomi Redmi Note 10", 5.0, true, true, "xiaomi-redmi-note10.jpg", "Xiaomi Redmi Note 10", 4000.0, "lorem ipsum dat color...", "xiaomi-redmi-note10" },
                    { "15", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4416), null, null, "Huawei P9 Lite 2017", 2.0, true, true, "huawei-p9-lite-2017.jpg", "Huawei P9 Lite 2017", 1850.0, "lorem ipsum dat color...", "huawei-p9-lite-2017" },
                    { "32", new DateTime(2021, 6, 14, 20, 43, 40, 395, DateTimeKind.Local).AddTicks(4484), null, null, "Playstation 4", 20.0, true, true, "playstation4.jpg", "Playstation 4", 6000.0, "lorem ipsum dat color...", "playstation4" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 1, "15" },
                    { 2, "16" },
                    { 2, "17" },
                    { 2, "18" },
                    { 8, "19" },
                    { 8, "20" },
                    { 5, "21" },
                    { 5, "22" },
                    { 3, "23" },
                    { 3, "24" },
                    { 6, "25" },
                    { 6, "26" },
                    { 4, "27" },
                    { 4, "28" },
                    { 4, "29" },
                    { 6, "29" },
                    { 6, "30" },
                    { 2, "14" },
                    { 2, "13" },
                    { 2, "12" },
                    { 1, "11" },
                    { 1, "2" },
                    { 1, "3" },
                    { 7, "31" },
                    { 1, "5" },
                    { 1, "6" },
                    { 1, "4" },
                    { 1, "7" },
                    { 1, "8" },
                    { 1, "9" },
                    { 1, "10" },
                    { 7, "32" }
                });

            migrationBuilder.InsertData(
                table: "ProductColor",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 3, "5" },
                    { 2, "4" },
                    { 1, "3" },
                    { 2, "2" },
                    { 1, "2" },
                    { 3, "1" },
                    { 2, "1" },
                    { 1, "1" },
                    { 4, "6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
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

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ColorId",
                table: "ProductColor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OrderItemId",
                table: "Ratings",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
