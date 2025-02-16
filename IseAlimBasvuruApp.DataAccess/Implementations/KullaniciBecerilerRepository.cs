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
    internal class KullaniciBecerilerRepository:GenericRepository<KullaniciBeceriler>, IKullaniciBecerilerRepository
    {
        private readonly IseAlimBasvuruAppDbContext _context;

        public KullaniciBecerilerRepository(IseAlimBasvuruAppDbContext context) : base(context)
        {
            {
                _context = context;
            }
        }
    }
}
