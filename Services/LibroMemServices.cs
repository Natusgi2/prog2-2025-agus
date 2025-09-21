using Bibliote.Models;
using Bibliote.Interface;
using System.Reflection.Metadata.Ecma335;

namespace Bibliote.Services
{
    public class LibroMemService : ILibroService
    {
    // Crear libros asociados
    List<Libro> _listaLibros = new List<Libro>
    {
        new Libro
        {
            Titulo = "Cien años de soledad",
            IdAutor = 1,
            Descripcion = "Novela emblemática del realismo mágico.",
            Genero = "Novela",
            ISBN = "978-0307474728",
            FechaPublicacion = new DateTime(1967, 5, 30),
            FechaEdicion = new DateTime(2014, 1, 1),
            Edicion = "Edición conmemorativa",
        },
        new Libro
        {
            Titulo = "La casa de los espíritus",
            IdAutor = 2,
            Descripcion = "Saga familiar llena de realismo mágico.",
            Genero = "Novela",
            ISBN = "978-0553383805",
            FechaPublicacion = new DateTime(1982, 1, 1),
            FechaEdicion = new DateTime(2005, 1, 1),
            Edicion = "Edición especial",

        },
        new Libro
        {
            Titulo = "La ciudad y los perros",
            IdAutor = 1,
            Descripcion = "Novela sobre la vida militar en Lima.",
            Genero = "Novela",
            ISBN = "978-8420471839",
            FechaPublicacion = new DateTime(1963, 1, 1),
            FechaEdicion = new DateTime(2012, 1, 1),
            Edicion = "Edición 50 aniversario",
        },
        new Libro
        {
            Titulo = "Ficciones",
            IdAutor = 2,
            Descripcion = "Colección de cuentos emblemáticos de Borges.",
            Genero = "Cuento",
            ISBN = "978-8420633121",
            FechaPublicacion = new DateTime(1944, 1, 1),
            FechaEdicion = new DateTime(1998, 1, 1),
            Edicion = "Edición crítica",
        },
        new Libro
        {
            Titulo = "El laberinto de la soledad",
            IdAutor = 3,
            Descripcion = "Ensayo sobre la identidad mexicana.",
            Genero = "Ensayo",
            ISBN = "978-9681605656",
            FechaPublicacion = new DateTime(1950, 1, 1),
            FechaEdicion = new DateTime(1999, 1, 1),
            Edicion = "Edición revisada",
        }
    };
        public Libro Add(Libro libro)
        {
            libro.Id = _listaLibros.Max(p => p.Id) + 1;
            _listaLibros.Add(libro);
            return libro;
        }

        public bool Delete(int id)
        {
            var libro = _listaLibros.FirstOrDefault(p => p.Id == id);
            if (libro != null)
            {
                _listaLibros.Remove(libro);
                return true;
            }
            return false;
           
        }

        public List<Libro> GetAll()
        {
            return _listaLibros;
        }

        public Libro? GetById(int id)
        {
            var libro = _listaLibros.FirstOrDefault(p => p.Id == id);
            return libro;
            
        }

        public Libro? Update(Libro libro, int id)
        {
            var libroLista = _listaLibros.FirstOrDefault(p => p.Id == id);
            if (libroLista == null) return null;

            libroLista.Titulo = libro.Titulo;
            libroLista.Descripcion = libro.Descripcion;
            libroLista.Genero = libro.Genero;
            libroLista.ISBN = libro.ISBN;
            libroLista.FechaPublicacion = libro.FechaPublicacion;
            libroLista.FechaEdicion = libro.FechaEdicion;
            libroLista.Edicion = libro.Edicion;
            
            return libroLista;
        }
    }
}