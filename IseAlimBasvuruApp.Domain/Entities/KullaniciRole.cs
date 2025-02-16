using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class KullaniciRole
    {
        public int KullaniciId { get; set; }
        public int RoleId { get; set; }

        public Kullanici Kullanici { get; set; }
        public Role Role { get; set; }
    }
}
