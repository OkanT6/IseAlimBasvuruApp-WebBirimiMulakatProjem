using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.Application.Services.Interfaces;
using IseAlimBasvuruApp.Domain.DTOs;
using IseAlimBasvuruApp.DataAccess.Enums;
using IseAlimBasvuruApp.Domain.Entities;
using IseAlimBasvuruApp.Domain.Interfaces;
using Mailjet.Client.Resources;
using Microsoft.EntityFrameworkCore;
//using Org.BouncyCastle.Crypto.Generators;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Implementations
{
    public class KullaniciService : IKullaniciService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        private readonly IMailjetService _mailjetService;

        public KullaniciService(IUnitOfWork unitOfWork, ITokenService tokenService, IMailjetService mailjetService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mailjetService= mailjetService;
        }

        // Kullanıcı Kaydı
        public async Task<KayitSonucuDTO> KayitOl(Domain.DTOs.KayitDTO kayitDTO)
        {
            
            //Kullanici zaten kayitli mi kontrolü
            var kullanici = _unitOfWork.Kullanici.getKullaniciByEmail(kayitDTO.Email);

            if (kullanici != null) {

                return new KayitSonucuDTO { BasariliMi = false, Mesaj = "Kullanıcı zaten kayıtlidir." };

            }
            else
            {
                Kullanici user = _unitOfWork.Kullanici.kullaniciKayit(kayitDTO);


                _unitOfWork.Kullanici.Add(user);

                _unitOfWork.Save();
                _unitOfWork.KullaniciRole.Add(new KullaniciRole { KullaniciId = user.KullaniciId, RoleId = 1 });
                _unitOfWork.Save();

                bool success = await _mailjetService.SendEmailAsync(user.Email, "Test Email", "Tebrikler! Kayıt işleminiz başarılı bir şekilde tamamlanmıştır. \n Okan Topdemir, the founder of IseAlimBasvuruApp");
                //Console.WriteLine(success ? "E-posta başarıyla gönderildi." : "E-posta gönderme başarısız oldu.");

                return new KayitSonucuDTO { BasariliMi = true, Mesaj = "Kullanıcı başarıyla kaydedildi." };
            }

            
        }

        // Kullanıcı Girişi
        public GirisSonucuDTO GirisYap(GirisDTO girisDto)
        {
            var user =  _unitOfWork.Kullanici.getKullaniciByEmail(girisDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(girisDto.Sifre, user.Sifre))
            {
                return new GirisSonucuDTO { BasariliMi = false, Mesaj = "Geçersiz e-posta veya şifre" };
            }

            var roller = _unitOfWork.Kullanici.getKullaniciRoller(user);
            var token = _tokenService.CreateToken(new KullaniciDTO { Id = user.KullaniciId, Ad = user.Adi, Email = user.Email, Roles = roller });

            return new GirisSonucuDTO { BasariliMi = true, Token = token,Mesaj="Basarili bir sekilde giris yapilm" };
        }

        // Kullanıcıya rol ata
        public async Task<bool> RoleAta(int userId, int roleId)
        {
            var user =  _unitOfWork.Kullanici.GetById(userId);
            if (user == null) return false;

            var rol =  _unitOfWork.Role.GetById(roleId);

            if(rol == null) return false;

            
            

            if (!_unitOfWork.KullaniciRole.Exists(user.KullaniciId, rol.RoleId))
            {
                _unitOfWork.KullaniciRole.Add(new KullaniciRole { KullaniciId = user.KullaniciId,RoleId=rol.RoleId });
                 _unitOfWork.Save();
            }

            return true;
        }

        // Kullanıcı bilgilerini getir
        // Kullanıcı bilgilerini getir
        public KullaniciDTO KullaniciGetir(int userId)
        {
            var user = _unitOfWork.Kullanici
                .Query() // Şimdi Include() kullanabiliriz
                .Include(u => u.KullaniciRoller)
                .ThenInclude(kr => kr.Role)
                .FirstOrDefault(u => u.KullaniciId == userId);

            if (user == null) return null;

            return new KullaniciDTO
            {
                Id = user.KullaniciId,
                Ad = user.Adi,
                Soyad = user.Soyadi,
                Email = user.Email,
                Roles = user.KullaniciRoller?
                            .Select(kr => kr.Role.RolAdi)
                            .ToList() ?? new List<string>(),
                ProfilFotografiUrl = user.ProfilFoto
            };
        }




        //// Kullanıcı bilgilerini güncelle
        //public async Task<bool> KullaniciGuncelle(KullaniciGuncelleDTO kullaniciGuncelleDto)
        //{
        //    var user = await _unitOfWork.Kullanici.GetByIdAsync(kullaniciGuncelleDto.Id);
        //    if (user == null) return false;

        //    user.Ad = kullaniciGuncelleDto.Ad;
        //    user.Email = kullaniciGuncelleDto.Email;
        //    _unitOfWork.Kullanici.Update(user);
        //    await _unitOfWork.SaveAsync();

        //    return true;
        //}

        //// Şifre değiştirme
        //public async Task<bool> SifreDegistir(string userId, string eskiSifre, string yeniSifre)
        //{
        //    var user = await _unitOfWork.Kullanici.GetByIdAsync(userId);
        //    if (user == null || !BCrypt.Net.BCrypt.Verify(eskiSifre, user.SifreHash))
        //        return false;

        //    user.SifreHash = BCrypt.Net.BCrypt.HashPassword(yeniSifre);
        //    await _unitOfWork.SaveAsync();
        //    return true;
        //}

        //// Şifremi unuttum
        //public async Task<bool> SifremiUnuttum(string email)
        //{
        //    var user = await _unitOfWork.Kullanici.GetByEmailAsync(email);
        //    if (user == null) return false;

        //    // Burada bir sıfırlama tokenı oluşturup e-posta ile gönderebilirsin.
        //    return true;
        //}

        //// Şifre sıfırlama
        //public async Task<bool> SifreSifirla(string userId, string yeniSifre)
        //{
        //    var user = await _unitOfWork.Kullanici.GetByIdAsync(userId);
        //    if (user == null) return false;

        //    user.SifreHash = BCrypt.Net.BCrypt.HashPassword(yeniSifre);
        //    await _unitOfWork.SaveAsync();
        //    return true;
        //}

        //// Kullanıcı çıkış yapma
        //public Task<bool> CikisYap(string userId)
        //{
        //    return Task.FromResult(true); // JWT kullanıyorsan çıkış için bir şey yapmana gerek yok
        //}
    }
}
