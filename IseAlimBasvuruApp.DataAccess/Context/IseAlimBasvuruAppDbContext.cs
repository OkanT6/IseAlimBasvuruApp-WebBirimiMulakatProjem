using IseAlimBasvuruApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.DataAccess.Context
{
    public class IseAlimBasvuruAppDbContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Role> Roller { get; set; }
        public DbSet<KullaniciRole> KullaniciRolleri { get; set; }
        public DbSet<Ilan> Ilanlar { get; set; }
        public DbSet<Basvuru> Basvurular { get; set; }
        public DbSet<Dosya> Dosyalar { get; set; }
        public DbSet<Sertifika> Sertifikalar { get; set; }
        public DbSet<Referans> Referanslar { get; set; }
        public DbSet<KullaniciIletisimBilgileri> KullaniciIletisimBilgileri { get; set; }
        public DbSet<KullaniciEgitimBilgileri> KullaniciEgitimBilgileri { get; set; }
        public DbSet<KullaniciDeneyimi> KullaniciDeneyimleri { get; set; }
        public DbSet<KullaniciBeceriler> KullaniciBecerileri { get; set; }
        public DbSet<Degerlendirme> Degerlendirmeler { get; set; }

        public DbSet<IsYeriLokasyon> IsYeriLokasyonlari { get; set; }

        public IseAlimBasvuruAppDbContext(DbContextOptions<IseAlimBasvuruAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Başvuru tablosu için BasvuruId'yi alternatif anahtar olarak belirliyoruz
            modelBuilder.Entity<Basvuru>()
                .HasKey(b => new { b.IlanId, b.KullaniciId });  // Birleşik anahtar olarak IlanId ve KullaniciId kullanılıyor

            modelBuilder.Entity<Basvuru>()
                .HasAlternateKey(b => b.BasvuruId);  // BaşvuruId'yi alternatif anahtar olarak ayarlıyoruz

            // Başvuru ile Degerlendirme arasındaki ilişkiyi tanımlama
            modelBuilder.Entity<Degerlendirme>()
                .HasKey(d => new { d.BasvuruId, d.KullaniciId });  // Degerlendirme için composite key

            modelBuilder.Entity<Degerlendirme>()
                .HasOne(d => d.Basvuru)
                .WithMany()
                .HasForeignKey(d => d.BasvuruId)  // BasvuruId üzerinden ilişki kuruyoruz
                .HasPrincipalKey(b => b.BasvuruId);  // Basvuru'nun BasvuruId'si üzerinden ilişki kuruyoruz

            modelBuilder.Entity<Degerlendirme>()
                .HasOne(d => d.KomisyonUyesi)
                .WithMany(k => k.Degerlendirmeler)
                .HasForeignKey(d => d.KullaniciId);

            // Kullanici - Role (Çoka çok ilişki)
            modelBuilder.Entity<KullaniciRole>()
                .HasKey(kr => new { kr.KullaniciId, kr.RoleId });

            modelBuilder.Entity<KullaniciRole>()
                .HasOne(kr => kr.Kullanici)
                .WithMany(k => k.KullaniciRoller)
                .HasForeignKey(kr => kr.KullaniciId);

            modelBuilder.Entity<KullaniciRole>()
                .HasOne(kr => kr.Role)
                .WithMany(r => r.KullaniciRoller)
                .HasForeignKey(kr => kr.RoleId);

            // Ilan - Kullanici (Başvuru ilişkisi)
            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.Kullanici)
                .WithMany(k => k.Basvurular)
                .HasForeignKey(b => b.KullaniciId)
                .OnDelete(DeleteBehavior.NoAction);  // Cascade delete işlemini devre dışı bırakıyoruz


            modelBuilder.Entity<Basvuru>()
                .HasOne(b => b.Ilan)
                .WithMany(i => i.Basvurular)
                .HasForeignKey(b => b.IlanId)
                    .OnDelete(DeleteBehavior.NoAction);  // Cascade delete işlemini devre dışı bırakıyoruz


            // Basvuru - Sertifika, Referans, Dosya ilişkisi
            modelBuilder.Entity<Sertifika>()
                .HasOne(s => s.Basvuru)
                .WithMany(b => b.Sertifikalar)
                .HasForeignKey(s => s.BasvuruId)  // Burada BasvuruId dış anahtarı kullanılıyor
                .HasPrincipalKey(b => b.BasvuruId);  // Burada BasvuruId anahtarını belirtiriz

            modelBuilder.Entity<Referans>()
                .HasOne(r => r.Basvuru)
                .WithMany(b => b.Referanslar)
                .HasForeignKey(r => r.BasvuruId)
                    .HasPrincipalKey(b => b.BasvuruId);  // Burada BasvuruId anahtarını belirtiriz



            modelBuilder.Entity<Dosya>()
                .HasOne(d => d.Basvuru)
                .WithMany(b => b.Dosyalar)
                .HasForeignKey(d => d.BasvuruId)
                    .HasPrincipalKey(b => b.BasvuruId);  // Burada BasvuruId anahtarını belirtiriz


            // Kullanici - Eğitim, Deneyim, Beceriler ilişkisi
            modelBuilder.Entity<KullaniciEgitimBilgileri>()
                .HasOne(e => e.Kullanici)
                .WithMany(k => k.EgitimBilgileri)
                .HasForeignKey(e => e.KullaniciId);

            modelBuilder.Entity<KullaniciDeneyimi>()
                .HasOne(d => d.Kullanici)
                .WithMany(k => k.Deneyimler)
                .HasForeignKey(d => d.KullaniciId);

            modelBuilder.Entity<KullaniciBeceriler>()
                .HasOne(b => b.Kullanici)
                .WithMany(k => k.Beceriler)
                .HasForeignKey(b => b.KullaniciId);

            // Kullanici - KullaniciIletisimBilgileri (Bire bir ilişki)
            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.IletisimBilgileri)
                .WithOne(i => i.Kullanici)
                .HasForeignKey<KullaniciIletisimBilgileri>(i => i.Id);

            //KullaniciEgitimBilgileri Konfigürasyonu
            modelBuilder.Entity<KullaniciEgitimBilgileri>()
                .Property(e => e.NotOrtalamasi)
                .HasPrecision(5, 2); // 5 basamaklı, 2 ondalık basamak
        }
    }
}
