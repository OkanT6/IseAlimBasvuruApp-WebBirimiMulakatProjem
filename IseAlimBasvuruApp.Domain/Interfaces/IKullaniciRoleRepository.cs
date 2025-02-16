using IseAlimBasvuruApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Interfaces
{
    public interface IKullaniciRoleRepository : IGenericRepository<KullaniciRole>
    {

        bool Exists(int kullaniciId, int roleId);
    }
}
