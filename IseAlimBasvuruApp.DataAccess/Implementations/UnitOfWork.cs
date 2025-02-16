using IseAlimBasvuruApp.DataAccess.Context;
using IseAlimBasvuruApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.DataAccess.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IseAlimBasvuruAppDbContext _context;

        public UnitOfWork(IseAlimBasvuruAppDbContext context)
        {
            _context = context;

            Basvuru=new BasvuruRepository(_context);

            Degerlendirme = new DegerlendirmeRepository(_context);
            
            Dosya = new DosyaRepository(_context);

            Ilan = new IlanRepository(_context);

            KullaniciBeceriler = new KullaniciBecerilerRepository(_context);

            KullaniciDeneyimi = new KullaniciDeneyimiRepository(_context);

            KullaniciEgitimBilgileri = new KullaniciEgitimBilgileriRepository(_context);

            KullaniciIletisimBilgileri = new KullaniciIletisimBilgileriRepository(_context);

            Kullanici = new KullaniciRepository(_context);

            KullaniciRole = new KullaniciRoleRepository(_context);

            Referans = new ReferansRepository(_context);

            Role = new RoleRepository(_context);

            Sertifika = new SertifikaRepository(_context);
        }
        public IBasvuruRepository Basvuru { get; private set; }

        public IDegerlendirmeRepository Degerlendirme { get; private set; }

        public IDosyaRepository Dosya { get; private set; }

        public IIlanRepository Ilan { get; private set; }

        public IKullaniciBecerilerRepository KullaniciBeceriler { get; private set; }

        public IKullaniciDeneyimiRepository KullaniciDeneyimi { get; private set; }

        public IKullaniciEgitimBilgileriRepository KullaniciEgitimBilgileri { get; private set; }

        public IKullaniciIletisimBilgileriRepository KullaniciIletisimBilgileri { get; private set; }

        public IKullaniciRepository Kullanici { get; private set; }

        public IKullaniciRoleRepository KullaniciRole { get; private set; }

        public IReferansRepository Referans { get; private set; }

        public IRoleRepository Role { get; private set; }

        public ISertifikaRepository Sertifika { get; private set; }

        

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
