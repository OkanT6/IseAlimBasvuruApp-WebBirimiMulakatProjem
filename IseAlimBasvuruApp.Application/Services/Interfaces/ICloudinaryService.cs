using IseAlimBasvuruApp.Application.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Interfaces
{
    public interface ICloudinaryService
    {
        public IstekSonucuDTO UploadProfilFoto(IFormFile file, int kullaniciId);

    }
}
