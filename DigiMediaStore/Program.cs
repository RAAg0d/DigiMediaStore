
using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.BusinessLogic.Services;
using DigiMediaStore.DataAccess;
using DigiMediaStore.DataAccess.Models;
using DigiMediaStore.DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "DigiMediaStore API",
        Description = "API для цифрового медиа-магазина с поддержкой пользователей, контента и заказов",
        Contact = new OpenApiContact
        {
            Name = "DigiMediaStore Support",
            Url = new Uri("https://github.com/DigiMediaStore/support")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // Включаем XML комментарии
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Database configuration
builder.Services.AddDbContext<DigiMediaStoreContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Host=localhost;Database=DigiMediaStore;Username=postgres;Password=23012006ar"));

// Register repositories and services
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Включаем Swagger для всех окружений (включая Docker)
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DigiMediaStore API v1");
        c.RoutePrefix = "swagger"; // Swagger UI будет доступен по /swagger
        c.DisplayRequestDuration();
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
    });

// Используем CORS
app.UseCors("AllowAll");

// Отключаем HTTPS редирект для Docker (можно включить при необходимости)
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
