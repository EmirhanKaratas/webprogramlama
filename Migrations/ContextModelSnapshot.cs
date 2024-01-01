﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proje.Models.siniflar;

#nullable disable

namespace Proje.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proje.Models.siniflar.Admin", b =>
                {
                    b.Property<long>("AdminID")
                        .HasColumnType("bigint");

                    b.Property<string>("AdminMail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdminSifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Proje.Models.siniflar.Biletler", b =>
                {
                    b.Property<int>("Biletİd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Biletİd"), 1L, 1);

                    b.Property<string>("Gün")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciTc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("güzergah")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("koltuk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zaman")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Biletİd");

                    b.ToTable("Biletlers");
                });

            modelBuilder.Entity("Proje.Models.siniflar.Güzergah", b =>
                {
                    b.Property<int>("GüzergahId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GüzergahId"), 1L, 1);

                    b.Property<string>("Sehirler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GüzergahId");

                    b.ToTable("Güzergahs");
                });

            modelBuilder.Entity("Proje.Models.siniflar.Hakkimizda", b =>
                {
                    b.Property<int>("Hakkımızda1ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hakkımızda1ID"), 1L, 1);

                    b.Property<string>("Aciklama1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hakkımızda1ID");

                    b.ToTable("Hakkimizdas");
                });

            modelBuilder.Entity("Proje.Models.siniflar.Iletisim", b =>
                {
                    b.Property<int>("IletisimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IletisimID"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Harita")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Konu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IletisimID");

                    b.ToTable("Iletisims");
                });

            modelBuilder.Entity("Proje.Models.siniflar.Seferler", b =>
                {
                    b.Property<int>("SeferlerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeferlerId"), 1L, 1);

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<DateTime>("Gün")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kapasite")
                        .HasColumnType("int");

                    b.Property<string>("Saat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("güzergah")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeferlerId");

                    b.ToTable("Seferlers");
                });

            modelBuilder.Entity("Proje.Models.siniflar.Users", b =>
                {
                    b.Property<string>("KullaniciTC")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("KullaniciMail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("KullaniciSifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciTC");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
