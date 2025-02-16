using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.DTOs
{
    public class GirisSonucuDTO
    {
        public bool BasariliMi { get; set; }
        public string Token { get; set; } // JWT Token

        public string Mesaj { get; set; }
        //public string Rol { get; set; }
    }
}
