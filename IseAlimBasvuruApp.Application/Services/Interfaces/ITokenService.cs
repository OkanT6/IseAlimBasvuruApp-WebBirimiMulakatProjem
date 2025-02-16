using IseAlimBasvuruApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(KullaniciDTO kullanici);
    }
}
