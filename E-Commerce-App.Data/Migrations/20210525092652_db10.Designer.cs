﻿// <auto-generated />
using System;
using E_Commerce_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Commerce_App.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210525092652_db10")]
    partial class db10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageAltTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMainCategory")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 419, DateTimeKind.Local).AddTicks(2412),
                            IsActive = false,
                            IsMainCategory = false,
                            Name = "Telefon",
                            Url = "telefon"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 419, DateTimeKind.Local).AddTicks(2494),
                            IsActive = false,
                            IsMainCategory = false,
                            Name = "Bilgisayar",
                            Url = "bilgisayar"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 419, DateTimeKind.Local).AddTicks(2498),
                            IsActive = false,
                            IsMainCategory = false,
                            Name = "Tv, Ev Elektroniği",
                            Url = "tv-ev-elektronigi"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 419, DateTimeKind.Local).AddTicks(2500),
                            IsActive = false,
                            IsMainCategory = false,
                            Name = "Bilgisayar Parçaları",
                            Url = "bilgisayar-parcalari"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 419, DateTimeKind.Local).AddTicks(2502),
                            IsActive = false,
                            IsMainCategory = false,
                            Name = "Foto, Kamera",
                            Url = "foto-kamera"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 419, DateTimeKind.Local).AddTicks(2507),
                            IsActive = false,
                            IsMainCategory = false,
                            Name = "Aksesuar",
                            Url = "aksesuar"
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 419, DateTimeKind.Local).AddTicks(2509),
                            IsActive = false,
                            IsMainCategory = false,
                            Name = "Oyun, Hobi",
                            Url = "oyun-hobi"
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 419, DateTimeKind.Local).AddTicks(2511),
                            IsActive = false,
                            IsMainCategory = false,
                            Name = "Ev, Mutfak",
                            Url = "ev-mutfak"
                        });
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Color");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "#f9f6ef",
                            IsActive = false,
                            Name = "Beyaz"
                        },
                        new
                        {
                            Id = 2,
                            Code = "#202020",
                            IsActive = false,
                            Name = "Siyah"
                        },
                        new
                        {
                            Id = 3,
                            Code = "#ba0c2f",
                            IsActive = false,
                            Name = "Kırmızı"
                        },
                        new
                        {
                            Id = 4,
                            Code = "#FECB2E",
                            IsActive = false,
                            Name = "Sarı"
                        },
                        new
                        {
                            Id = 5,
                            Code = "#147EFB",
                            IsActive = false,
                            Name = "Mavi"
                        },
                        new
                        {
                            Id = 6,
                            Code = "#53D769",
                            IsActive = false,
                            Name = "Yeşil"
                        });
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SelectedColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDelete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Discount")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHome")
                        .HasColumnType("bit");

                    b.Property<string>("MainImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 416, DateTimeKind.Local).AddTicks(4015),
                            Description = "aciklama 1",
                            Discount = 5.0,
                            IsActive = false,
                            IsHome = true,
                            MainImage = "none",
                            Name = "Ürün 1",
                            Price = 1000.0,
                            ShortDescription = "lorem ipsum dat color...",
                            Url = "product1"
                        },
                        new
                        {
                            Id = "2",
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 418, DateTimeKind.Local).AddTicks(2028),
                            Description = "aciklama 2",
                            Discount = 5.0,
                            IsActive = false,
                            IsHome = true,
                            MainImage = "none",
                            Name = "Ürün 2",
                            Price = 1200.0,
                            ShortDescription = "lorem ipsum dat color...",
                            Url = "product2"
                        },
                        new
                        {
                            Id = "3",
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 418, DateTimeKind.Local).AddTicks(2136),
                            Description = "aciklama 3",
                            Discount = 5.0,
                            IsActive = false,
                            IsHome = true,
                            MainImage = "none",
                            Name = "Ürün 3",
                            Price = 1300.0,
                            ShortDescription = "lorem ipsum dat color...",
                            Url = "product3"
                        },
                        new
                        {
                            Id = "4",
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 418, DateTimeKind.Local).AddTicks(2141),
                            Description = "aciklama 4",
                            Discount = 5.0,
                            IsActive = false,
                            IsHome = true,
                            MainImage = "none",
                            Name = "Ürün 4",
                            Price = 1400.0,
                            ShortDescription = "lorem ipsum dat color...",
                            Url = "product4"
                        },
                        new
                        {
                            Id = "5",
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 418, DateTimeKind.Local).AddTicks(2145),
                            Description = "aciklama 5",
                            Discount = 10.0,
                            IsActive = false,
                            IsHome = true,
                            MainImage = "none",
                            Name = "Ürün 5",
                            Price = 1500.0,
                            ShortDescription = "lorem ipsum dat color...",
                            Url = "product5"
                        },
                        new
                        {
                            Id = "6",
                            CreationDate = new DateTime(2021, 5, 25, 12, 26, 51, 418, DateTimeKind.Local).AddTicks(2152),
                            Description = "aciklama 6",
                            Discount = 20.0,
                            IsActive = false,
                            IsHome = true,
                            MainImage = "none",
                            Name = "Ürün 6",
                            Price = 2000.0,
                            ShortDescription = "lorem ipsum dat color...",
                            Url = "product6"
                        });
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.ProductCategory", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");

                    b.HasData(
                        new
                        {
                            ProductId = "1",
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = "1",
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = "1",
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = "2",
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = "2",
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = "3",
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = "4",
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = "5",
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = "6",
                            CategoryId = 4
                        });
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.ProductColor", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ColorId");

                    b.HasIndex("ColorId");

                    b.ToTable("ProductColor");

                    b.HasData(
                        new
                        {
                            ProductId = "1",
                            ColorId = 1
                        },
                        new
                        {
                            ProductId = "1",
                            ColorId = 2
                        },
                        new
                        {
                            ProductId = "1",
                            ColorId = 3
                        },
                        new
                        {
                            ProductId = "2",
                            ColorId = 1
                        },
                        new
                        {
                            ProductId = "2",
                            ColorId = 2
                        },
                        new
                        {
                            ProductId = "3",
                            ColorId = 1
                        },
                        new
                        {
                            ProductId = "4",
                            ColorId = 2
                        },
                        new
                        {
                            ProductId = "5",
                            ColorId = 3
                        },
                        new
                        {
                            ProductId = "6",
                            ColorId = 4
                        });
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.CartItem", b =>
                {
                    b.HasOne("E_Commerce_App.Core.Entities.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_App.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Image", b =>
                {
                    b.HasOne("E_Commerce_App.Core.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.OrderItem", b =>
                {
                    b.HasOne("E_Commerce_App.Core.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_App.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.ProductCategory", b =>
                {
                    b.HasOne("E_Commerce_App.Core.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_App.Core.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.ProductColor", b =>
                {
                    b.HasOne("E_Commerce_App.Core.Entities.Color", "Color")
                        .WithMany("ProductColors")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_App.Core.Entities.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Color", b =>
                {
                    b.Navigation("ProductColors");
                });

            modelBuilder.Entity("E_Commerce_App.Core.Entities.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductColors");
                });
#pragma warning restore 612, 618
        }
    }
}
