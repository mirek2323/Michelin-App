﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductDosageApp.Data;

#nullable disable

namespace ProductDosageApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240909115317_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductDosageApp.Models.Bestandteil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bestand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bestandteile");
                });

            modelBuilder.Entity("ProductDosageApp.Models.Dosage", b =>
                {
                    b.Property<int>("DosageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DosageID"));

                    b.Property<string>("Dos1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos10")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos11")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos7")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dos9")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DosageID");

                    b.ToTable("Dosages");
                });

            modelBuilder.Entity("ProductDosageApp.Models.DosageBestandteil", b =>
                {
                    b.Property<int>("DosageBestandteilID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DosageBestandteilID"));

                    b.Property<int>("BestandteilID")
                        .HasColumnType("int");

                    b.Property<int>("DosageID")
                        .HasColumnType("int");

                    b.HasKey("DosageBestandteilID");

                    b.HasIndex("BestandteilID");

                    b.HasIndex("DosageID");

                    b.ToTable("DosageBestandteile");
                });

            modelBuilder.Entity("ProductDosageApp.Models.Produkt", b =>
                {
                    b.Property<int>("ProduktID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduktID"));

                    b.Property<int>("Anzahl")
                        .HasColumnType("int");

                    b.Property<string>("MKZ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrapNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZVar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProduktID");

                    b.ToTable("Produkts");
                });

            modelBuilder.Entity("ProductDosageApp.Models.ProduktDosage", b =>
                {
                    b.Property<int>("ProduktDosageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduktDosageID"));

                    b.Property<int>("DosageID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktID")
                        .HasColumnType("int");

                    b.HasKey("ProduktDosageID");

                    b.HasIndex("DosageID");

                    b.HasIndex("ProduktID");

                    b.ToTable("ProduktDosages");
                });

            modelBuilder.Entity("ProductDosageApp.Models.DosageBestandteil", b =>
                {
                    b.HasOne("ProductDosageApp.Models.Bestandteil", "Bestandteil")
                        .WithMany()
                        .HasForeignKey("BestandteilID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductDosageApp.Models.Dosage", "Dosage")
                        .WithMany("DosageBestandteile")
                        .HasForeignKey("DosageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bestandteil");

                    b.Navigation("Dosage");
                });

            modelBuilder.Entity("ProductDosageApp.Models.ProduktDosage", b =>
                {
                    b.HasOne("ProductDosageApp.Models.Dosage", "Dosage")
                        .WithMany("ProduktDosages")
                        .HasForeignKey("DosageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductDosageApp.Models.Produkt", "Produkt")
                        .WithMany("ProduktDosages")
                        .HasForeignKey("ProduktID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dosage");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("ProductDosageApp.Models.Dosage", b =>
                {
                    b.Navigation("DosageBestandteile");

                    b.Navigation("ProduktDosages");
                });

            modelBuilder.Entity("ProductDosageApp.Models.Produkt", b =>
                {
                    b.Navigation("ProduktDosages");
                });
#pragma warning restore 612, 618
        }
    }
}
