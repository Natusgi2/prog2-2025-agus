using Bibliote.Interface;
using Bibliote.Services;
using Microsoft.EntityFrameworkCore;
using Bibliote.Context;
using DotNetEnv;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Bibliote.Models;

// Cargar variables de entorno ANTES del builder
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Añadir cadena de conexión y DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar AuthOptions
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection("Jwt"));

// Añadir DbContext
builder.Services
    .AddDbContext<BibliotecaDbContext>(options => options.UseSqlServer(connectionString));

// Añadir JWT Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Añadir Authorization
builder.Services.AddAuthorization();

// Añadir controllers
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// DI - Añadir servicios de la capa de negocio
builder.Services.AddScoped<IPersonaService, PersonaDbService>();
builder.Services.AddScoped<IAutorService, AutorDbService>();
builder.Services.AddScoped<ILibroService, LibroDbService>();
builder.Services.AddScoped<IAuthService, AuthService>();


// Consuir la app
var app = builder.Build();

// Configurar el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Añadir Authentication
app.UseAuthentication();

// Añadir Authorization
app.UseAuthorization();


app.MapControllers();

app.Run();
