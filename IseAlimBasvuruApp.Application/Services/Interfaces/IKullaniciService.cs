using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Interfaces
{
    public interface IKullaniciService
    {
        // Kullanıcı Kaydı
        Task<KayitSonucuDTO> KayitOl(Domain.DTOs.KayitDTO kayitDTO);

        // Kimlik Doğrulama (JWT Token Döndürür)
        GirisSonucuDTO GirisYap(GirisDTO girisDto);

        // Kullanıcının Rolüne Göre Yetkilendirme
        Task<bool> RoleAta(int userId, int role);

        // Kullanıcı Bilgilerini Getir
         KullaniciDTO KullaniciGetir(int userId);

        // Kullanıcı Bilgilerini Güncelle
        //Task<bool> KullaniciGuncelle(KullaniciGuncelleDTO kullaniciGuncelleDto);

        // Şifre İşlemleri
        //Task<bool> SifreDegistir(string userId, string eskiSifre, string yeniSifre);
        //Task<bool> SifremiUnuttum(string email);
        //Task<bool> SifreSifirla(string userId, string yeniSifre);

        // Çıkış Yap
        //Task<bool> CikisYap(string userId);
    }
}
