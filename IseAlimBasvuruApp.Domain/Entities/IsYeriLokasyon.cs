using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class IsYeriLokasyon
    {
        public int Id { get; set; }

        public string OfisAdi { get; set; }

        public string Ulke { get; set; }

        public string Sehir {  get; set; }

        ICollection<Ilan> Ilan { get; set; }
    }
}
