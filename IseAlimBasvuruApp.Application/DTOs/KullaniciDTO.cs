using IseAlimBasvuruApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.DTOs
{
    public class KullaniciDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public List<string> Roles { get; set; }

        public string ProfilFotografiUrl { get; set; }
    }
}
