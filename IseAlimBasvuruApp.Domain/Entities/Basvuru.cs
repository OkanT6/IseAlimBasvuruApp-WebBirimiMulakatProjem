using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities

{
    public class Basvuru
    {
        public int BasvuruId { get; set; }  // Identity olacak ve alternate key olacak
        public int IlanId { get; set; }
        public int KullaniciId { get; set; }

        public Ilan Ilan { get; set; }
        public Kullanici Kullanici { get; set; }

        public ICollection<Sertifika> Sertifikalar { get; set; } = new List<Sertifika>();
        public ICollection<Referans> Referanslar { get; set; } = new List<Referans>();
        public ICollection<Dosya> Dosyalar { get; set; } = new List<Dosya>();

        public ICollection<Degerlendirme> Degerlendirmeler { get; set; } = new List<Degerlendirme>();

    }


}
