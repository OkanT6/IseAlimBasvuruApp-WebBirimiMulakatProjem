using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class KullaniciBeceriler
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string BeceriAdi { get; set; }

        public Kullanici Kullanici { get; set; }
    }
}
