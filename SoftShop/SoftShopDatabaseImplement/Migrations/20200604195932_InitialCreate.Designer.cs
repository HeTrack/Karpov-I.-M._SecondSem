﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftShopDatabaseImplement;

namespace SoftShopDatabaseImplement.Migrations
{
    [DbContext(typeof(SoftShopDatabase))]
    [Migration("20200604195932_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.Implementer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImplementerFIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PauseTime")
                        .HasColumnType("int");

                    b.Property<int>("WorkingTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Implementers");
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.MessageInfo", b =>
                {
                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDelivery")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ClientId");

                    b.ToTable("MessageInfoes");
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImplementerId")
                        .HasColumnType("int");

                    b.Property<int>("PackId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ImplementerId");

                    b.HasIndex("PackId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.Pack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PackName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Packs");
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.PackSoft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("PackId")
                        .HasColumnType("int");

                    b.Property<int>("SoftId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PackId");

                    b.HasIndex("SoftId");

                    b.ToTable("PackSofts");
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.Soft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SoftName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Softs");
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.MessageInfo", b =>
                {
                    b.HasOne("SoftShopDatabaseImplement.Models.Client", "Client")
                        .WithMany("MessageInfoes")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("SoftShopDatabaseImplement.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftShopDatabaseImplement.Models.Implementer", "Implementer")
                        .WithMany("Orders")
                        .HasForeignKey("ImplementerId");

                    b.HasOne("SoftShopDatabaseImplement.Models.Pack", "Pack")
                        .WithMany("Orders")
                        .HasForeignKey("PackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoftShopDatabaseImplement.Models.PackSoft", b =>
                {
                    b.HasOne("SoftShopDatabaseImplement.Models.Pack", "Pack")
                        .WithMany("PackSofts")
                        .HasForeignKey("PackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftShopDatabaseImplement.Models.Soft", "Soft")
                        .WithMany("PackSofts")
                        .HasForeignKey("SoftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}