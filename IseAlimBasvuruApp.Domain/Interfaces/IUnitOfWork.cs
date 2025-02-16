using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IBasvuruRepository Basvuru { get; }
        IDegerlendirmeRepository Degerlendirme { get; }

        IDosyaRepository Dosya { get; }

        IIlanRepository Ilan { get; }

        IKullaniciBecerilerRepository KullaniciBeceriler { get; }
        IKullaniciDeneyimiRepository KullaniciDeneyimi { get; }
        IKullaniciEgitimBilgileriRepository KullaniciEgitimBilgileri { get; }

        IKullaniciIletisimBilgileriRepository KullaniciIletisimBilgileri { get; }

        IKullaniciRepository Kullanici { get; }
        IKullaniciRoleRepository KullaniciRole { get; }

        IReferansRepository Referans { get; }

        IRoleRepository Role { get; }

        ISertifikaRepository Sertifika { get; }


        int Save();





    }
}
