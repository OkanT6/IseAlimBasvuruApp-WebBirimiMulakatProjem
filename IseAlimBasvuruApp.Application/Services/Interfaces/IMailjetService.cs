using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IseAlimBasvuruApp.Application.Services.Interfaces
{
    public interface IMailjetService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string body);
    }
}
