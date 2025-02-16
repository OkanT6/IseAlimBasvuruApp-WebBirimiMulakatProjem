using IseAlimBasvuruApp.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class MailjetService:IMailjetService
{
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public MailjetService(IConfiguration configuration)
    {

        _apiKey = configuration["Mailjet:ApiKey"];
        _apiSecret = configuration["Mailjet:ApiSecret"];
        _fromEmail = configuration["Mailjet:FromEmail"];
        _fromName = configuration["Mailjet:FromName"];
    }

    public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
    {
        var client = new HttpClient();
        var requestUri = "https://api.mailjet.com/v3.1/send";
        var json = new
        {
            Messages = new[]
            {
                new
                {
                    From = new { Email = _fromEmail, Name = _fromName },
                    To = new[] { new { Email = toEmail } },
                    Subject = subject,
                    TextPart = body
                }
            }
        };

        var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_apiKey}:{_apiSecret}")));

        var response = await client.PostAsync(requestUri, content);

        return response.IsSuccessStatusCode;
    }
}
