using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class KullaniciDeneyimi
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string IsPozisyonu { get; set; }
        public string CalismaTipi { get; set; }
        public string IsYeriAdi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime? AyrilmaTarihi { get; set; }
        public string Konum { get; set; }
        public string KonumTipi { get; set; }
        public string IsTanimi { get; set; }

        public Kullanici Kullanici { get; set; }
    }
}
