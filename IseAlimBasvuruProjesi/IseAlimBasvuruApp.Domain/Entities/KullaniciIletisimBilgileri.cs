using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class KullaniciIletisimBilgileri
    {
        public int Id { get; set; }
        //public int KullaniciId { get; set; }
        //public string Email { get; set; }
        public string Telefon { get; set; }
        public string? Adres { get; set; }

        public Kullanici Kullanici { get; set; }
    }
}
