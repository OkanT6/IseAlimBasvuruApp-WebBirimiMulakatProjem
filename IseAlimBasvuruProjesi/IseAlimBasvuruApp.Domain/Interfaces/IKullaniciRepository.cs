using IseAlimBasvuruApp.Domain.DTOs;
using IseAlimBasvuruApp.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Interfaces
{
    public interface IKullaniciRepository : IGenericRepository<Kullanici>
    {
        Kullanici getKullaniciByEmail(string email);

        Kullanici kullaniciKayit(KayitDTO kayitDTO);

        List<string> getKullaniciRoller(Kullanici user);

    }
}