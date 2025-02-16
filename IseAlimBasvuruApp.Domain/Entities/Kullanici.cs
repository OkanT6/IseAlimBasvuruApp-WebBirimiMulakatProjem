using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using IseAlimBasvuruApp.DataAccess.Enums;


namespace IseAlimBasvuruApp.Domain.Entities
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Sifre { get; set; }
        public string? ProfilFoto { get; set; }
        public DateOnly DogumTarihi { get; set; }
        public Cinsiyet Cinsiyet { get; set; }


        public string Email { get; set; }

        // Bire bir ilişki
        [JsonIgnore]
        public KullaniciIletisimBilgileri? IletisimBilgileri { get; set; }

        // Bire çok ilişkiler
        [JsonIgnore]
        public ICollection<KullaniciEgitimBilgileri> EgitimBilgileri { get; set; } = new List<KullaniciEgitimBilgileri>();
        [JsonIgnore]
        public ICollection<KullaniciDeneyimi> Deneyimler { get; set; } = new List<KullaniciDeneyimi>();
        [JsonIgnore]
        public ICollection<KullaniciBeceriler> Beceriler { get; set; } = new List<KullaniciBeceriler>();
        [JsonIgnore]
        public ICollection<Ilan> YayinlananIlanlar { get; set; }=new List<Ilan>();




        // Çoka çok ilişki (Roller)
        [JsonIgnore]
        public ICollection<Basvuru> Basvurular { get; set; } = new List<Basvuru>();
        [JsonIgnore]
        public ICollection<KullaniciRole> KullaniciRoller { get; set; } = new List<KullaniciRole>();
        [JsonIgnore]
        public ICollection<Degerlendirme> Degerlendirmeler { get; set; }=new List<Degerlendirme>();

    }


}
