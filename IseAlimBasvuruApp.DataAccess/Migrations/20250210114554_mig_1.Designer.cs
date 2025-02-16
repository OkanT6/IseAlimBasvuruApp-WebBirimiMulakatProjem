﻿// <auto-generated />
using System;
using IseAlimBasvuruApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IseAlimBasvuruApp.DataAccess.Migrations
{
    [DbContext(typeof(IseAlimBasvuruAppDbContext))]
    [Migration("20250210114554_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Basvuru", b =>
                {
                    b.Property<int>("IlanId")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<int>("BasvuruId")
                        .HasColumnType("int");

                    b.HasKey("IlanId", "KullaniciId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Basvurular");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Degerlendirme", b =>
                {
                    b.Property<int>("BasvuruId")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<int?>("BasvuruIlanId")
                        .HasColumnType("int");

                    b.Property<int?>("BasvuruKullaniciId")
                        .HasColumnType("int");

                    b.Property<int>("Puan")
                        .HasColumnType("int");

                    b.Property<string>("Rapor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BasvuruId", "KullaniciId");

                    b.HasIndex("KullaniciId");

                    b.HasIndex("BasvuruIlanId", "BasvuruKullaniciId");

                    b.ToTable("Degerlendirmeler");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Dosya", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasvuruId")
                        .HasColumnType("int");

                    b.Property<string>("DosyaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BasvuruId");

                    b.ToTable("Dosyalar");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Ilan", b =>
                {
                    b.Property<int>("IlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IlanId"));

                    b.Property<bool>("IlanAktif")
                        .HasColumnType("bit");

                    b.Property<string>("IlanBaslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IlanIsTanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IlanYayinlanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("YoneticiId")
                        .HasColumnType("int");

                    b.HasKey("IlanId");

                    b.HasIndex("YoneticiId");

                    b.ToTable("Ilanlar");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciId"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProfilFoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciBeceriler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BeceriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("KullaniciBecerileri");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciDeneyimi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AyrilmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("CalismaTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsPozisyonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsTanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsYeriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Konum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KonumTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("KullaniciDeneyimleri");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciEgitimBilgileri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiplomaTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<decimal>("NotOrtalamasi")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("NotOrtalamasiTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OkulAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("KullaniciEgitimBilgileri");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciIletisimBilgileri", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KullaniciIletisimBilgileri");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciRole", b =>
                {
                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("KullaniciId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("KullaniciRolleri");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Referans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasvuruId")
                        .HasColumnType("int");

                    b.Property<string>("ReferansTanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BasvuruId");

                    b.ToTable("Referanslar");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RolAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RolTanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Sertifika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasvuruId")
                        .HasColumnType("int");

                    b.Property<string>("DosyaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BasvuruId");

                    b.ToTable("Sertifikalar");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Basvuru", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Ilan", "Ilan")
                        .WithMany("Basvurular")
                        .HasForeignKey("IlanId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Kullanici", "Kullanici")
                        .WithMany("Basvurular")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ilan");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Degerlendirme", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Basvuru", "Basvuru")
                        .WithMany()
                        .HasForeignKey("BasvuruId")
                        .HasPrincipalKey("BasvuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Kullanici", "KomisyonUyesi")
                        .WithMany("Degerlendirmeler")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Basvuru", null)
                        .WithMany("Degerlendirmeler")
                        .HasForeignKey("BasvuruIlanId", "BasvuruKullaniciId");

                    b.Navigation("Basvuru");

                    b.Navigation("KomisyonUyesi");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Dosya", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Basvuru", "Basvuru")
                        .WithMany("Dosyalar")
                        .HasForeignKey("BasvuruId")
                        .HasPrincipalKey("BasvuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basvuru");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Ilan", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Kullanici", "Yonetici")
                        .WithMany("YayinlananIlanlar")
                        .HasForeignKey("YoneticiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Yonetici");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciBeceriler", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Kullanici", "Kullanici")
                        .WithMany("Beceriler")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciDeneyimi", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Kullanici", "Kullanici")
                        .WithMany("Deneyimler")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciEgitimBilgileri", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Kullanici", "Kullanici")
                        .WithMany("EgitimBilgileri")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciIletisimBilgileri", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Kullanici", "Kullanici")
                        .WithOne("IletisimBilgileri")
                        .HasForeignKey("IseAlimBasvuruApp.Domain.Entities.KullaniciIletisimBilgileri", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.KullaniciRole", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Kullanici", "Kullanici")
                        .WithMany("KullaniciRoller")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Role", "Role")
                        .WithMany("KullaniciRoller")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Referans", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Basvuru", "Basvuru")
                        .WithMany("Referanslar")
                        .HasForeignKey("BasvuruId")
                        .HasPrincipalKey("BasvuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basvuru");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Sertifika", b =>
                {
                    b.HasOne("IseAlimBasvuruApp.Domain.Entities.Basvuru", "Basvuru")
                        .WithMany("Sertifikalar")
                        .HasForeignKey("BasvuruId")
                        .HasPrincipalKey("BasvuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basvuru");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Basvuru", b =>
                {
                    b.Navigation("Degerlendirmeler");

                    b.Navigation("Dosyalar");

                    b.Navigation("Referanslar");

                    b.Navigation("Sertifikalar");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Ilan", b =>
                {
                    b.Navigation("Basvurular");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Kullanici", b =>
                {
                    b.Navigation("Basvurular");

                    b.Navigation("Beceriler");

                    b.Navigation("Degerlendirmeler");

                    b.Navigation("Deneyimler");

                    b.Navigation("EgitimBilgileri");

                    b.Navigation("IletisimBilgileri");

                    b.Navigation("KullaniciRoller");

                    b.Navigation("YayinlananIlanlar");
                });

            modelBuilder.Entity("IseAlimBasvuruApp.Domain.Entities.Role", b =>
                {
                    b.Navigation("KullaniciRoller");
                });
#pragma warning restore 612, 618
        }
    }
}
