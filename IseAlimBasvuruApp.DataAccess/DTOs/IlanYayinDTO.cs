using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.DataAccess.DTOs
{
    public class IlanYayinDTO
    {
        public string isTanimi { get; set; }
        public string baslik { get; set; }

        public DateOnly IlanYayinlanmaTarihi { get; set; }

        public int basvuranKisiSayisi { get; set; }

    }
}
