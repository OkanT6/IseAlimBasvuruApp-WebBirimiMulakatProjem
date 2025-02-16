using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using IseAlimBasvuruApp.Application.DTOs;
using IseAlimBasvuruApp.Application.Services.Interfaces;
using IseAlimBasvuruApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Implementations
{
    public class CloudinaryService : ICloudinaryService
    {

        private readonly Cloudinary _cloudinary;
        private readonly IUnitOfWork _unitOfWork;



        public CloudinaryService(Cloudinary cloudinary,IUnitOfWork unitOfWork)
        {
            _cloudinary = cloudinary;
            _unitOfWork = unitOfWork;

        }
        IstekSonucuDTO ICloudinaryService.UploadProfilFoto(IFormFile file, int kullaniciId)
        {
            if (file == null || file.Length == 0)
            {
                return new IstekSonucuDTO
                {
                    statusCode = 400,
                    message = "Geçersiz dosya."
                };


            }

            // Desteklenen formatları belirle
            var allowedFormats = new List<string> { "image/jpeg", "image/png", "image/bmp" };

            if (!allowedFormats.Contains(file.ContentType.ToLower()))
            {
                return new IstekSonucuDTO
                {
                    statusCode = 400,
                    message = "Sadece JPEG, PNG ve BMP formatındaki fotoğraflar yüklenebilir."
                };
            }


            // Cloudinary'ye yükleme
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Folder = "EruKampusSporProfilPhotos" // Cloudinary'deki klasör adı
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new IstekSonucuDTO
                {
                    statusCode = 500,
                    message = "Fotoğraf yüklenemedi."
                };
                
            }

            // URL'yi KullaniciDetay tablosuna kaydet
            //var kullaniciId = int.Parse(User.FindFirst("id").Value); // Token'dan kullanıcı ID'si alınır
            var kullanici =  _unitOfWork.Kullanici.GetById(kullaniciId);



            if (kullanici == null)
            {
                return new IstekSonucuDTO
                {
                    statusCode = 500,
                    message = "Kullanıcı bulunamadı."
                };
                
            }

            kullanici.ProfilFoto=uploadResult.SecureUrl.ToString();
            _unitOfWork.Save();
            return new IstekSonucuDTO
            {
                statusCode = 200,
                message = "Fotoğraf başarıyla yüklendi."
            };
        }
    }
}
