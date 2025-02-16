//using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.Domain.DTOs;
using IseAlimBasvuruApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Interfaces
{
    public interface IIlanService
    {
        public Ilan IlanOlusturAsync(IlanDTO ilanDTO, int yoneticiId);
        public Task KapatIlanAsync(int ilanId);

        public Task<IEnumerable<IlanYayinDTO>> ilanlariListeleAktif();

        public Task<Ilan?> IlanGetirAsync(int ilanId);

        public Task<IlanYayinDetayDTO> IlanDetayGoruntule(int ilanId);



    }
}
