using Bibliote.Models;
using Bibliote.Context;
using Bibliote.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Bibliote.Services
{
    public class LibroDbService : ILibroService
    {
        private readonly BibliotecaDbContext _context;

        public LibroDbService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public Libro Add(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
            return libro;
        }

        public bool Delete(int id)
        {
            var libro = GetById(id);
            if (libro == null) return false;
            _context.Libros.Remove(libro);
            _context.SaveChanges();
            return true;
        }

        public List<Libro> GetAll()
        {
            return _context.Libros.Include(l => l.Autor).ToList();
        }

        public Libro? GetById(int id)
        {
            return _context.Libros.Find(id);
        }

        public Libro? Update(Libro libro, int id)
        {
            var existingLibro = GetById(id);
            if (existingLibro == null) return null;

            existingLibro.Titulo = libro.Titulo;
            existingLibro.Descripcion = libro.Descripcion;
            existingLibro.Genero = libro.Genero;
            existingLibro.ISBN = libro.ISBN;
            existingLibro.FechaPublicacion = libro.FechaPublicacion;
            existingLibro.FechaEdicion = libro.FechaEdicion;
            existingLibro.Edicion = libro.Edicion;
            existingLibro.IdAutor = libro.IdAutor;

            _context.SaveChanges();

            return existingLibro;
        }
    }
}