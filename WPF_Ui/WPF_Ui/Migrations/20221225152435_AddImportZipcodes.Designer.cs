﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPF_Ui.Services.Data;

#nullable disable

namespace WPF_Ui.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221225152435_AddImportZipcodes")]
    partial class AddImportZipcodes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ArticleGroupId")
                        .HasColumnType("int");

                    b.Property<int>("MwstId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nr")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MwstId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.ArticleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ArticleGroup");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nr")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NetPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.MWST", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("TaxValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("MWST");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceBrutto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceNetto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("OrderId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Town");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Article", b =>
                {
                    b.HasOne("Semesterprojekt_Datenbank.Model.ArticleGroup", "ArticleGroup")
                        .WithMany("Articles")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Semesterprojekt_Datenbank.Model.MWST", "MWST")
                        .WithMany("Articles")
                        .HasForeignKey("MwstId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleGroup");

                    b.Navigation("MWST");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Customer", b =>
                {
                    b.HasOne("Semesterprojekt_Datenbank.Model.Town", "Town")
                        .WithMany("Customers")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Invoice", b =>
                {
                    b.HasOne("Semesterprojekt_Datenbank.Model.Customer", null)
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Semesterprojekt_Datenbank.Model.Order", "Order")
                        .WithOne("Invoice")
                        .HasForeignKey("Semesterprojekt_Datenbank.Model.Invoice", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Order", b =>
                {
                    b.HasOne("Semesterprojekt_Datenbank.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Position", b =>
                {
                    b.HasOne("Semesterprojekt_Datenbank.Model.Article", "Article")
                        .WithMany("Positions")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Semesterprojekt_Datenbank.Model.Order", "Order")
                        .WithMany("Positions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Article", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.ArticleGroup", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Customer", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.MWST", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Order", b =>
                {
                    b.Navigation("Invoice")
                        .IsRequired();

                    b.Navigation("Positions");
                });

            modelBuilder.Entity("Semesterprojekt_Datenbank.Model.Town", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
