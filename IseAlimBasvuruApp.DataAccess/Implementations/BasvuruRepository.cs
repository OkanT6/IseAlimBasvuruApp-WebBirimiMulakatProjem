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
    public class BasvuruRepository : GenericRepository<Basvuru>,IBasvuruRepository
    {
        private readonly IseAlimBasvuruAppDbContext _context;

        public BasvuruRepository(IseAlimBasvuruAppDbContext context) : base(context)
        {
            {
                _context = context;
            }
        }
    }
}
