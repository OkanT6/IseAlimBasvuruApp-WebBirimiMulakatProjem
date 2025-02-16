using IseAlimBasvuruApp.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.DTOs
{
    public class KayitDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public DateOnly DogumTarihi { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
    }
}
