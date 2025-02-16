//using IseAlimBasvuruApp.Application.DTOs;
//using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.DataAccess.Context;
using IseAlimBasvuruApp.DataAccess.Enums;
using IseAlimBasvuruApp.Domain.DTOs;
using IseAlimBasvuruApp.Domain.Entities;
using IseAlimBasvuruApp.Domain.Interfaces;
using Mailjet.Client.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.DataAccess.Implementations
{
    internal class KullaniciRepository:GenericRepository<Kullanici>, IKullaniciRepository
    {
        private readonly IseAlimBasvuruAppDbContext _context;

        public KullaniciRepository(IseAlimBasvuruAppDbContext context) : base(context)
        {
            {
                _context = context;
            }
        }

        public Kullanici getKullaniciByEmail(string email)
        {
            return Find(k => k.Email == email).FirstOrDefault();
        }

        public Kullanici kullaniciKayit(KayitDTO kayitDTO) {

            //Kullanici kayıt etme işlemi
            var user = new Kullanici
            {
                Adi = kayitDTO.Ad,
                Soyadi = kayitDTO.Soyad,

                Email = kayitDTO.Email,
                Sifre = BCrypt.Net.BCrypt.HashPassword(kayitDTO.Sifre),
                Cinsiyet = kayitDTO.Cinsiyet,
                DogumTarihi = kayitDTO.DogumTarihi
            };

            if (user.Cinsiyet == 0)
            {
                user.ProfilFoto = "https://res.cloudinary.com/davayayg8/image/upload/v1737917807/defaultErkekSporcuProfilPhoto_cknkam.jpg";
            }
            else
            {
                user.ProfilFoto = "https://res.cloudinary.com/davayayg8/image/upload/v1737917826/defaultKad%C4%B1nSporcuProfilPhoto_fstyqz.jpg";
            }

            return user;
        }

        List<string> IKullaniciRepository.getKullaniciRoller(Kullanici user)
        {
            return this.Query()
                .Include(k => k.KullaniciRoller)
            .ThenInclude(kr => kr.Role)
                .Where(k => k.KullaniciId == user.KullaniciId) // Kullanıcı ID'sine göre filtreleme yapın (isteğe bağlı)
                .SelectMany(k => k.KullaniciRoller) // Kullanıcı rollerini düzleştir
                .Select(kr => kr.Role.RolAdi) // Sadece rol adlarını seç
                .ToList();
        }
    }
}
