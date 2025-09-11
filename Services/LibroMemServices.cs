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
            Descripcion = "Novela emblemática del realismo mágico.",
            Genero = "Novela",
            ISBN = "978-0307474728",
            FechaPublicacion = new DateTime(1967, 5, 30),
            FechaEdicion = new DateTime(2014, 1, 1),
            Edcicion = "Edición conmemorativa",
        },
        new Libro
        {
            Titulo = "La casa de los espíritus",
            Descripcion = "Saga familiar llena de realismo mágico.",
            Genero = "Novela",
            ISBN = "978-0553383805",
            FechaPublicacion = new DateTime(1982, 1, 1),
            FechaEdicion = new DateTime(2005, 1, 1),
            Edcicion = "Edición especial",

        },
        new Libro
        {
            Titulo = "La ciudad y los perros",
            Descripcion = "Novela sobre la vida militar en Lima.",
            Genero = "Novela",
            ISBN = "978-8420471839",
            FechaPublicacion = new DateTime(1963, 1, 1),
            FechaEdicion = new DateTime(2012, 1, 1),
            Edcicion = "Edición 50 aniversario",
        },
        new Libro
        {
            Titulo = "Ficciones",
            Descripcion = "Colección de cuentos emblemáticos de Borges.",
            Genero = "Cuento",
            ISBN = "978-8420633121",
            FechaPublicacion = new DateTime(1944, 1, 1),
            FechaEdicion = new DateTime(1998, 1, 1),
            Edcicion = "Edición crítica",
        },
        new Libro
        {
            Titulo = "El laberinto de la soledad",
            Descripcion = "Ensayo sobre la identidad mexicana.",
            Genero = "Ensayo",
            ISBN = "978-9681605656",
            FechaPublicacion = new DateTime(1950, 1, 1),
            FechaEdicion = new DateTime(1999, 1, 1),
            Edcicion = "Edición revisada",
        }
    };
        public Libro Add(Libro libro)
        {
            libro.Id = _listaLibros.Max(p => p.Id) + 1;
            _listaLibros.Add(libro);
            return libro;
        }

        public void Delete(int id)
        {
            var libro = _listaLibros.FirstOrDefault(p => p.Id == id);
            if (libro != null)
            {
                _listaLibros.Remove(libro);
            }
           
        }

        public List<Libro> GetAll()
        {
            return _listaLibros;
        }

        public Libro GetById(int id)
        {
            var libro = _listaLibros.FirstOrDefault(p => p.Id == id);
            return libro;
            
        }

        public Libro Update(Libro libro, int id)
        {
            var libroLista = _listaLibros.FirstOrDefault(p => p.Id == id);
            if (libroLista != null)
            {
                libroLista.Titulo = libro.Titulo;
                libroLista.Descripcion = libro.Descripcion;
                libroLista.Genero = libro.Genero;
                libroLista.ISBN = libro.ISBN;
                libroLista.FechaPublicacion = libro.FechaPublicacion;
                libroLista.FechaEdicion = libro.FechaEdicion;
                libroLista.Edcicion = libro.Edcicion;
            
            }
            return libroLista;
        }
    }
}