using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.DTOs
{
    public class SifreDegistirDTO
    {
        public string KullaniciId { get; set; }
        public string EskiSifre { get; set; }
        public string YeniSifre { get; set; }
    }
}
