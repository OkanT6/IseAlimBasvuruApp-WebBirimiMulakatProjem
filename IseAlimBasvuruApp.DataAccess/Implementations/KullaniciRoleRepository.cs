using IseAlimBasvuruApp.DataAccess.Context;
using IseAlimBasvuruApp.Domain.Entities;
using IseAlimBasvuruApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.DataAccess.Implementations
{
    internal class KullaniciRoleRepository:GenericRepository<KullaniciRole>, IKullaniciRoleRepository
    {
        private readonly IseAlimBasvuruAppDbContext _context;

        public KullaniciRoleRepository(IseAlimBasvuruAppDbContext context) : base(context)
        {
            {
                _context = context;
            }
        }

        public bool Exists(int kullaniciId, int roleId)
        {
            var record=_context.Set<KullaniciRole>().Where(kr => kr.KullaniciId == kullaniciId && kr.RoleId == roleId).ToList;
            if (record != null)
            {
                return true;
            }
            else { return false; }
            
        }
    }
}
