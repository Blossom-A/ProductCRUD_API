﻿// <auto-generated />
using Assignment1_redo1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1_redo1.Migrations
{
    [DbContext(typeof(ProductDBContext))]
    [Migration("20250506150844_SeedProductData")]
    partial class SeedProductData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment1_redo1.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "A classic baseball cap...",
                            Name = "Baseball Cap",
                            Price = 19.99m
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Flowing, floor-length maxi dress...",
                            Name = "Maxi Dress",
                            Price = 59.99m
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "A pair of slim-fit chinos...",
                            Name = "Slim Fit Chinos",
                            Price = 44.95m
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Cozy hoodie with a bold graphic...",
                            Name = "Hoodie",
                            Price = 49.99m
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "Comfortable and stylish...",
                            Name = "Jogger Sweatpants",
                            Price = 39.99m
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "High-performance running shoes...",
                            Name = "Running Shoes",
                            Price = 89.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
