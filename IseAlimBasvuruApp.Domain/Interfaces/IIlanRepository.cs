using IseAlimBasvuruApp.Domain.DTOs;
using IseAlimBasvuruApp.Domain.Entities;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Interfaces
{
    public interface IIlanRepository : IGenericRepository<Ilan>
    {
        public Task<IEnumerable<IlanYayinDTO>> IlanlariListeleAktif();

        public Ilan IlanOlusturAsync(IlanDTO ilanDTO, int yoneticiId);

        public Task KapatIlanAsync(int ilanId);

        public Task<IlanYayinDetayDTO> IlanDetayiniGoruntule(Ilan ilan);

    }
}
