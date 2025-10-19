using Bibliote.Interface;
using Bibliote.Services;
using Microsoft.EntityFrameworkCore;
using Bibliote.Context;
using DotNetEnv;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Bibliote.Models;
using Microsoft.OpenApi.Models;

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

builder.Services.AddHttpClient<PreguntaApiService>();
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
builder.Services.AddSwaggerGen(c =>
{
    // Configuración básica de Swagger
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tu API", Version = "v1" });

    // Configuración de seguridad para JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce el token JWT en este formato: Bearer {token}"
    });

    // Configuración de seguridad para API Key
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Name = "X-API-KEY",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Introduce la API Key para autenticación entre servicios"
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
        },
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
});

// DI - Añadir servicios de la capa de negocio
builder.Services.AddScoped<IPersonaService, PersonaDbService>();
builder.Services.AddScoped<IAutorService, AutorDbService>();
builder.Services.AddScoped<ILibroService, LibroDbService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPreguntaService, PreguntaApiService>();


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

// Añadir el middleware de API Key ANTES de Authentication
app.UseMiddleware<Biblioteca.Middleware.ApiKeyMiddleware>();

// Añadir Authentication
app.UseAuthentication();

// Añadir Authorization
app.UseAuthorization();


app.MapControllers();

app.Run();
