using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class Referans
    {
        public int Id { get; set; }
        public int BasvuruId { get; set; }
        public string ReferansTanimi { get; set; }

        public Basvuru Basvuru { get; set; }
    }
}
