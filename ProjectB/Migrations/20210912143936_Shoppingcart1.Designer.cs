﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectB.Models;

namespace ProjectB.Migrations
{
    [DbContext(typeof(DishDbContext))]
    [Migration("20210912143936_Shoppingcart1")]
    partial class Shoppingcart1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ProjectB.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Punjabi",
                            Description = "Punjabi cuisine is famous all over the country for its delicious flavor."
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Rajasthani",
                            Description = "The state of Rajasthan is widely known for its distinct variety of dishes."
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Bengali",
                            Description = "Bengali food is a combination of fish, rice, and lentils."
                        });
                });

            modelBuilder.Entity("ProjectB.Models.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBestSeller")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DishId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            DishId = 1,
                            CategoryId = 3,
                            Description = "lorem ipsum",
                            DishName = "Aloo Posto",
                            ImageThumbnailUrl = "/img/b1.jpg",
                            ImageUrl = "/img/b1.jpg",
                            IsBestSeller = false,
                            Price = 230m
                        },
                        new
                        {
                            DishId = 2,
                            CategoryId = 3,
                            Description = "lorem ipsum",
                            DishName = "Doi Maach",
                            ImageThumbnailUrl = "/img/b1.jpg",
                            ImageUrl = "/img/b1.jpg",
                            IsBestSeller = true,
                            Price = 330m
                        },
                        new
                        {
                            DishId = 3,
                            CategoryId = 3,
                            Description = "lorem ipsum",
                            DishName = "Rasmalai",
                            ImageThumbnailUrl = "/img/b1.jpg",
                            ImageUrl = "/img/b1.jpg",
                            IsBestSeller = false,
                            Price = 100m
                        },
                        new
                        {
                            DishId = 4,
                            CategoryId = 1,
                            Description = "lorem ipsum",
                            DishName = "Aloo Paratha",
                            ImageThumbnailUrl = "/img/p1.jpg",
                            ImageUrl = "/img/p1.jpg",
                            IsBestSeller = true,
                            Price = 200m
                        },
                        new
                        {
                            DishId = 5,
                            CategoryId = 1,
                            Description = "lorem ipsum",
                            DishName = "Makki Roti",
                            ImageThumbnailUrl = "/img/p1.jpg",
                            ImageUrl = "/img/p1.jpg",
                            IsBestSeller = true,
                            Price = 300m
                        },
                        new
                        {
                            DishId = 6,
                            CategoryId = 2,
                            Description = "lorem ipsum",
                            DishName = "Mawa Kachori",
                            ImageThumbnailUrl = "/img/r1.jpg",
                            ImageUrl = "/img/r1.jpg",
                            IsBestSeller = false,
                            Price = 350m
                        },
                        new
                        {
                            DishId = 7,
                            CategoryId = 2,
                            Description = "lorem ipsum",
                            DishName = "Mirchi Bada",
                            ImageThumbnailUrl = "/img/r1.jpg",
                            ImageUrl = "/img/r1.jpg",
                            IsBestSeller = true,
                            Price = 150m
                        });
                });

            modelBuilder.Entity("ProjectB.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Pincode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ProjectB.Models.Dish", b =>
                {
                    b.HasOne("ProjectB.Models.Category", "Category")
                        .WithMany("Dishes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProjectB.Models.Category", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}