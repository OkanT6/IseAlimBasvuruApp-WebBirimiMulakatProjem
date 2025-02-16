using IseAlimBasvuruApp.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class Ilan
    {
        public int IlanId { get; set; }
        public string IlanBaslik { get; set; }
        public DateTime IlanYayinlanmaTarihi { get; set; }

        public DateTime IlanKapatilmaTarihi { get; set; }
        public bool IlanAktif { get; set; }
        public string IlanIsTanimi { get; set; }

        public string IlanIsTanimiUzun {  get; set; }

        public CalismaSekli CalismaSekli { get; set; }

        public Deneyim Deneyim { get; set; }

        public CalismaTipi CalismaTipi { get; set; }

        public Cinsiyet ArananCinsiyet { get; set; }


        public int IsYeriLokasyonId { get; set; }

        public int YoneticiId { get; set; }
        public Kullanici Yonetici { get; set; }

        public ICollection<Basvuru> Basvurular { get; set; } = new List<Basvuru>();

        
        public IsYeriLokasyon IsYeriLokasyon { get; set; }

        
    }
}
