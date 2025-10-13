using Bibliote.Models;
using Bibliote.Context;
using Bibliote.Interface;
using Microsoft.EntityFrameworkCore;

namespace Bibliote.Services
{
    public class AutorDbService : IAutorService
    {
        private readonly BibliotecaDbContext _context;

        public AutorDbService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public Autor Add(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return autor;
        }

        public bool Delete(int id)
        {
            var autor = GetById(id);
            if (autor == null) return false;
            _context.Autores.Remove(autor);
            _context.SaveChanges();
            return true;
        }

        public List<Autor> GetAll()
        {
            return _context.Autores.Include(a => a.Libros).ToList();
        }

        public Autor? GetById(int id)
        {
            return _context.Autores.Find(id);
        }

        public Autor? Update(Autor autor, int id)
        {
            var existingAutor = GetById(id);
            if (existingAutor == null) return null;

            existingAutor.Nombre = autor.Nombre;
            existingAutor.Apellido = autor.Apellido;
            existingAutor.Descripcion = autor.Descripcion;
            existingAutor.Nacionalidad = autor.Nacionalidad;

            _context.SaveChanges();

            return existingAutor;
        }
    }
}