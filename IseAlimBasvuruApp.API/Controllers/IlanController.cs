//using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.Application.Services.Interfaces;
using IseAlimBasvuruApp.Domain.DTOs;
using IseAlimBasvuruApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IseAlimBasvuruApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IlanController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;
        private readonly IIlanService _ilanService;

        public IlanController(IKullaniciService kullaniciService, IIlanService ilanService)
        {
            _kullaniciService = kullaniciService;
            _ilanService = ilanService;
        }

        
        [HttpGet]
        public async Task<IlanYayinDetayDTO> IlanDetayGoruntule([FromQuery] int id)
        {
            return await _ilanService.IlanDetayGoruntule(id);   
        }

        [HttpGet]
        public async Task<IEnumerable<IlanYayinDTO>> ilanlariListeleAktif()
        {
        

            return await _ilanService.ilanlariListeleAktif();
        }

        [HttpPost]
        [Authorize(Roles = "Yönetici")]
        public IActionResult ilanYayinla(IlanDTO ilanDTO) {

            //Tokenden ID değerine ulaşıyorum
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Kimlik doğrulaması yapılırken hata oluştu.");

            // Token'daki ID'yi int'e dönüştür
            if (!int.TryParse(userIdClaim, out var id))
                return BadRequest("Token'daki kullanıcı ID'si geçerli bir sayı değil.");

            var yoneticiId = id;

            Ilan ilan =_ilanService.IlanOlusturAsync(ilanDTO, yoneticiId);
            if(ilan!=null)
            {
                return Ok("Ilan basarili bir sekilde eklenmistir");
            }
            else
            {
                return Ok("Ilan eklerken bir sorunla karşılaşıldı");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Yönetici")]
        public async Task<IActionResult> IlaniKapat(int ilanId)
        {
            //Belki ileride her yönetici sadece kendi ilanını kapatbilsin şartı koşabilirim
            //Şu anda böyle bir şart yok!

            var ilan = await _ilanService.IlanGetirAsync(ilanId); 
            if (ilan == null)
            {
                return NotFound(new { message = "İlan bulunamadı." });
            }

            await _ilanService.KapatIlanAsync(ilanId);

            return Ok(new { message = "İlan başarıyla kapatıldı." });
        }




    }

    
}
