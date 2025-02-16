using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class KullaniciEgitimBilgileri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string OkulAdi { get; set; }
        public string DiplomaTipi { get; set; }
        public string NotOrtalamasiTipi { get; set; }
        public decimal NotOrtalamasi { get; set; }

        public Kullanici Kullanici { get; set; }
    }
}
