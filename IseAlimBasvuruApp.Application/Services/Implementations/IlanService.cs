//using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.Application.Services.Interfaces;
using IseAlimBasvuruApp.Domain.DTOs;
using IseAlimBasvuruApp.Domain.Entities;
using IseAlimBasvuruApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Implementations
{
    public class IlanService:IIlanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        

        public async Task KapatIlanAsync(int ilanId)
        {
           await _unitOfWork.Ilan.KapatIlanAsync(ilanId);
        }

        public async Task<IEnumerable<IlanYayinDTO>> ilanlariListeleAktif()
        {
            return await _unitOfWork.Ilan.IlanlariListeleAktif();
        }
        public async Task<Ilan?> IlanGetirAsync(int ilanId)
        {
            return _unitOfWork.Ilan.GetById(ilanId); // Generic GetByIdAsync kullanılıyor
        }

        Task<IlanYayinDetayDTO> IIlanService.IlanDetayGoruntule(int ilanId)
        {
            Ilan ilan = _unitOfWork.Ilan.GetById(ilanId);

            

            return _unitOfWork.Ilan.IlanDetayiniGoruntule(ilan);
        }

        Ilan IIlanService.IlanOlusturAsync(IlanDTO ilanDTO, int yoneticiId)
        {
            // Ilan nesnesi oluşturuluyor
            Ilan ilan = _unitOfWork.Ilan.IlanOlusturAsync(ilanDTO, yoneticiId);

            // Eğer ilan null değilse, kaydedip döndürüyoruz
            if (ilan != null)
            {
                _unitOfWork.Ilan.Add(ilan);  // Yeni ilan ekleniyor
                _unitOfWork.Save();  // Veritabanına kaydediliyor
                return ilan;  // Oluşturulan ilan döndürülüyor
            }
            else
            {
                // Eğer ilan null ise, null döndürülüyor
                return null;
            }
        }
    }
}
