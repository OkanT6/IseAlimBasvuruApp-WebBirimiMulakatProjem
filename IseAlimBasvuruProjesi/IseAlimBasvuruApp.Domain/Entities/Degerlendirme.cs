using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class Degerlendirme
    {
        public int KullaniciId { get; set; }
        public int BasvuruId { get; set; }
        public int Puan { get; set; }
        public string Rapor { get; set; }

        public Kullanici KomisyonUyesi { get; set; }
        public Basvuru Basvuru { get; set; }
    }
}
