using IseAlimBasvuruApp.DataAccess.Context;
using IseAlimBasvuruApp.Domain.DTOs;

//using IseAlimBasvuruApp.DataAccess.DTOs;
using IseAlimBasvuruApp.Domain.Entities;
using IseAlimBasvuruApp.Domain.Interfaces;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.DataAccess.Implementations
{
    internal class IlanRepository:GenericRepository<Ilan>,IIlanRepository
    {
        private readonly IseAlimBasvuruAppDbContext _context;

        public IlanRepository(IseAlimBasvuruAppDbContext context) : base(context)
        {
            {
                _context = context;
            }
        }

        public Task KapatIlanAsync(int ilanId)
        {
            var ilan = this.GetById(ilanId);
            if (ilan == null) throw new Exception("İlan bulunamadı.");

            if (!ilan.IlanAktif) throw new InvalidOperationException("İlan zaten kapalı.");

            ilan.IlanKapatilmaTarihi = DateTime.UtcNow;
            ilan.IlanAktif = false;

            _context.SaveChanges();

            return Task.CompletedTask;
        }

        Task<IEnumerable<IlanYayinDTO>> IIlanRepository.IlanlariListeleAktif()
        {
            IEnumerable<Ilan> ilanlar =_context.Ilanlar.Where(i => i.IlanAktif == true);
            List<IlanYayinDTO> ilanlarDTOs = new List<IlanYayinDTO>(); // Değiştirilebilir liste kullan

            foreach (var ilan in ilanlar)
            {
                ilanlarDTOs.Add(new IlanYayinDTO
                {  // Append yerine Add() kullan
                    id=ilan.IlanId,
                    baslik = ilan.IlanBaslik,
                    isTanimi = ilan.IlanIsTanimi,
                    IlanYayinlanmaTarihi = DateOnly.FromDateTime(ilan.IlanYayinlanmaTarihi),
                    basvuranKisiSayisi = ilan.Basvurular.Count(),
                    
                    
                });
            }
            return Task.FromResult<IEnumerable<IlanYayinDTO>>(ilanlarDTOs);

        }

        

        public async Task<Ilan?> IlanGetirAsync(int ilanId)
        {
            return this.GetById(ilanId); // Generic GetByIdAsync kullanılıyor
        }

        Task<IlanYayinDetayDTO> IIlanRepository.IlanDetayiniGoruntule(Ilan ilan)
        {
            if (ilan != null)
            {
                IlanYayinDetayDTO ilanYayinDetayDTO = new IlanYayinDetayDTO
                {
                    Id = ilan.IlanId,
                    IlanBaslik = ilan.IlanBaslik,
                    IlanYayinlanmaTarihi = ilan.IlanYayinlanmaTarihi,
                    IlanKapatilmaTarihi = ilan.IlanKapatilmaTarihi,
                    IlanAktif = ilan.IlanAktif,
                    IlanIsTanimi = ilan.IlanIsTanimi,
                    IlanIsTanimiUzun = ilan.IlanIsTanimiUzun,
                    CalismaSekli = ilan.CalismaSekli,
                    Deneyim = ilan.Deneyim,
                    CalismaTipi = ilan.CalismaTipi,
                    ArananCinsiyet = ilan.ArananCinsiyet
                };
                return Task.FromResult(ilanYayinDetayDTO);
            }
            else
            {
                return null;
            }
        }

        Ilan IIlanRepository.IlanOlusturAsync(IlanDTO ilanDTO, int yoneticiId)
        {
            var ilan = new Ilan()
            {
                IlanBaslik = ilanDTO.IlanBaslik,
                IlanIsTanimi = ilanDTO.IlanIsTanimi,
                IlanIsTanimiUzun = ilanDTO.IlanIsTanimiUzun,
                YoneticiId = yoneticiId,
                IlanYayinlanmaTarihi = DateTime.UtcNow,
                IlanAktif = true,
                CalismaSekli = ilanDTO.CalismaSekli,
                Deneyim = ilanDTO.Deneyim,
                CalismaTipi = ilanDTO.CalismaTipi,
                ArananCinsiyet = ilanDTO.ArananCinsiyet,
                IsYeriLokasyonId = ilanDTO.IsYeriLokasyonId

            };




            return (ilan);

        }
    }
}

