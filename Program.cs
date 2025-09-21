using Bibliote.Interface;
using Bibliote.Services;
using Microsoft.EntityFrameworkCore;
using Bibliote.Context;
using DotNetEnv;

// 0. Cargar variables de entorno ANTES del builder
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// 1. Añadir cadena de conexión y DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IFileStorageService, FileStorageService>();
//builder.Services.AddScoped<IPersonaService, PersonaFileService>();
//builder.Services.AddSingleton<IPersonaService, PersonaMemService>();
builder.Services.AddScoped<IPersonaService, PersonaDbService>();
builder.Services.AddScoped<IAutorService, AutorDbService>();
builder.Services.AddScoped<ILibroService, LibroDbService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
