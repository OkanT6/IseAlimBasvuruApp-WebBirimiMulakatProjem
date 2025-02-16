using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RolAdi { get; set; }
        public string RolTanimi { get; set; }

        public ICollection<KullaniciRole> KullaniciRoller { get; set; } = new List<KullaniciRole>();
    }
}
