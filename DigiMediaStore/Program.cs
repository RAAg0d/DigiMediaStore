
using DigiMediaStore.BusinessLogic.Interfaces;
using DigiMediaStore.BusinessLogic.Services;
using DigiMediaStore.DataAccess;
using DigiMediaStore.DataAccess.Models;
using DigiMediaStore.DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "DigiMediaStore API", 
        Version = "v1" 
    });
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
