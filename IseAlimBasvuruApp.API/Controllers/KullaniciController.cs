using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.Domain.DTOs;
using IseAlimBasvuruApp.Application.Services.Implementations;
using IseAlimBasvuruApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IseAlimBasvuruApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;
        private readonly ICloudinaryService _cloudinaryService;   

        public KullaniciController(IKullaniciService kullaniciService,ICloudinaryService cloudinaryService)
        {
            _kullaniciService = kullaniciService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [Authorize(Roles = "Komisyon,Yönetici")]
        public IActionResult getKullanici([FromQuery] int id)
        {
            var result = _kullaniciService.KullaniciGetir(id);
            if (result == null) 
                return NotFound("Böyle bir kullanıcı yoktur");
            else
            return Ok(result); // Sadece `result` JSON olarak dönecek!
        }

        [HttpPost]
        public async Task<IActionResult> kayitOl([FromBody] Domain.DTOs.KayitDTO kayitDTO)
        {
            var sonuc = await _kullaniciService.KayitOl(kayitDTO); // await ekledik!
            return Ok(sonuc);
        }


        [HttpPost]
        public IActionResult girisYap([FromBody] GirisDTO girisDTO)
        {

            var sonuc = _kullaniciService.GirisYap(girisDTO);
            return Ok(sonuc);
        }
        [HttpGet]
        [Authorize(Roles = "Aday")]
        public IActionResult profilBilgileriniGoruntule() {

            //Tokenden ID değerine ulaşıyorum
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Kimlik doğrulaması yapılırken hata oluştu.");

            // Token'daki ID'yi int'e dönüştür
            if (!int.TryParse(userIdClaim, out var id))
                return BadRequest("Token'daki kullanıcı ID'si geçerli bir sayı değil.");

            var kullaniciId = id;

            var sonuc=_kullaniciService.KullaniciGetir(kullaniciId);
            return Ok(sonuc);
        }

        [HttpPost]
        [Authorize(Roles = "Aday")]
        public IActionResult profilFotografiniDegistir([FromQuery] IFormFile file)
        {
            //Tokenden ID değerine ulaşıyorum
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Kimlik doğrulaması yapılırken hata oluştu.");

            // Token'daki ID'yi int'e dönüştür
            if (!int.TryParse(userIdClaim, out var id))
                return BadRequest("Token'daki kullanıcı ID'si geçerli bir sayı değil.");

            var kullaniciId = id;

           var istekSonucu= _cloudinaryService.UploadProfilFoto(file, kullaniciId);

            if (istekSonucu.statusCode == 200)
                return Ok(istekSonucu.message);
            else
                return BadRequest("Hata Kodu:" + istekSonucu.message + " " +istekSonucu.statusCode );

        }


    }
}
