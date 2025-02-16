using IseAlimBasvuruApp.DataAccess.Context;
using IseAlimBasvuruApp.Domain.Interfaces;
using IseAlimBasvuruApp.DataAccess.Implementations;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IseAlimBasvuruApp.Application.Services.Implementations;
using IseAlimBasvuruApp.Application.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using CloudinaryDotNet;

var builder = WebApplication.CreateBuilder(args);

// ? **Veritaban� Ba�lant�s�n� Ekle**
builder.Services.AddDbContext<IseAlimBasvuruAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? **UnitOfWork ve Repository Ba��ml�l�klar�n� Ekle**
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// KullaniciService ba��ml�l��� ekleniyor
builder.Services.AddTransient<IKullaniciService, KullaniciService>();

// TokenService ba��ml�l��� ekleniyor
builder.Services.AddTransient<ITokenService, TokenService>();

// E�er TokenService ba�ka ba��ml�l�klar i�eriyorsa onlar� da eklemelisin!

// DI Container'a MailjetService'i ekliyoruz
builder.Services.AddSingleton<IMailjetService, MailjetService>();

builder.Services.AddScoped<IIlanService, IlanService>();

//builder.Services.AddSingleton<ICloudinaryService, CloudinaryService>();


//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//{
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
//});

// ? **JWT Authentication Yap�land�rmas�**
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty)),
        };
    });


// Cloudinary yap�land�rmas�n� al
var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings");
var account = new Account(
    cloudinarySettings["CloudName"],
    cloudinarySettings["ApiKey"],
    cloudinarySettings["ApiSecret"]
);

// Cloudinary servisini ekle
builder.Services.AddSingleton(new Cloudinary(account));

// CloudinaryService'in ba��ml�l���n� ekle
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

// ? **CORS Politikas�**
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5247",
                "https://localhost:7190",
                "http://192.168.1.254:5247",
                "https://192.168.1.254:7190") // Hem localhost hem de IP adreslerini ekleyin
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // AllowCredentials eklemek gerekebilir
    });
});


// ? **Swagger Deste�i**
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IseAlimBasvuruApp API", Version = "v1" });

    // JWT Token deste�i
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT kullanarak yetkilendirme i�in 'Bearer <TOKEN>' format�nda giriniz."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddControllers();



builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 5247); // HTTP
    options.Listen(System.Net.IPAddress.Any, 7190, listenOptions => // HTTPS
    {
        listenOptions.UseHttps();
    });
});



var app = builder.Build();

// ? **Middleware Konfig�rasyonu**
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IseAlimBasvuruApp API v1");
        c.RoutePrefix = string.Empty; // Swagger'� direkt ana sayfa yapar
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
