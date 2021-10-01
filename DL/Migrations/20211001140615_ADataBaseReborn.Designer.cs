﻿// <auto-generated />
using System;
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DL.Migrations
{
    [DbContext(typeof(P1DBContext))]
    [Migration("20211001140615_ADataBaseReborn")]
    partial class ADataBaseReborn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("NameProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("VendorBranchesVendorId")
                        .HasColumnType("integer");

                    b.Property<int>("VendorId")
                        .HasColumnType("integer");

                    b.HasKey("InventoryId");

                    b.HasIndex("NameProductId");

                    b.HasIndex("VendorBranchesVendorId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Models.LineItem", b =>
                {
                    b.Property<int>("LineItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int?>("OrdersOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("VendorId")
                        .HasColumnType("integer");

                    b.HasKey("LineItemId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomersCustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Totals")
                        .HasColumnType("numeric");

                    b.Property<int>("VendorId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomersCustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrdersOrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Models.VendorBranches", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CityState")
                        .HasColumnType("text");

                    b.Property<string>("GrandCompany")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("VendorId");

                    b.ToTable("VendorBranches");
                });

            modelBuilder.Entity("Models.Inventory", b =>
                {
                    b.HasOne("Models.Products", "Name")
                        .WithMany("Inventory")
                        .HasForeignKey("NameProductId");

                    b.HasOne("Models.VendorBranches", null)
                        .WithMany("Inventories")
                        .HasForeignKey("VendorBranchesVendorId");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Models.LineItem", b =>
                {
                    b.HasOne("Models.Orders", null)
                        .WithMany("LineItems")
                        .HasForeignKey("OrdersOrderId");
                });

            modelBuilder.Entity("Models.Orders", b =>
                {
                    b.HasOne("Models.Customers", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomersCustomerId");
                });

            modelBuilder.Entity("Models.Products", b =>
                {
                    b.HasOne("Models.Orders", null)
                        .WithMany("Products")
                        .HasForeignKey("OrdersOrderId");
                });

            modelBuilder.Entity("Models.Customers", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Models.Orders", b =>
                {
                    b.Navigation("LineItems");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Models.Products", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("Models.VendorBranches", b =>
                {
                    b.Navigation("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
