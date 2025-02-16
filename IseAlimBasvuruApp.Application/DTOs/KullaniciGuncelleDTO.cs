using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.DTOs
{
    public class KullaniciGuncelleDTO
    {
        public string Id { get; set; } // Güncellenecek kullanıcı ID
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
    }
}
