/*using Bibliote.Models;
using Bibliote.Interface;
using System.Reflection.Metadata.Ecma335;

namespace Bibliote.Services
{
    public class AutorMemService : IAutorService
    {
        List<Autor> _listaAutores = new List<Autor>
    {
        new Autor
        {
            Nombre = "Gabriel",
            Apellido = "García Márquez",
            Descripcion = "Escritor colombiano, ganador del Premio Nobel de Literatura en 1982.",
            Nacionalidad = "Colombiana",
            Libros = new List<Libro>()
        },
        new Autor
        {
            Nombre = "Isabel",
            Apellido = "Allende",
            Descripcion = "Escritora chilena reconocida por sus novelas de realismo mágico.",
            Nacionalidad = "Chilena",
            Libros = new List<Libro>()
        },
        new Autor
        {
            Nombre = "Mario",
            Apellido = "Vargas Llosa",
            Descripcion = "Novelista y ensayista peruano, Premio Nobel de Literatura 2010.",
            Nacionalidad = "Peruana",
            Libros = new List<Libro>()
        },
        new Autor
        {
            Nombre = "Jorge Luis",
            Apellido = "Borges",
            Descripcion = "Escritor argentino, célebre por sus cuentos y ensayos.",
            Nacionalidad = "Argentina",
            Libros = new List<Libro>()
        },
        new Autor
        {
            Nombre = "Octavio",
            Apellido = "Paz",
            Descripcion = "Poeta, ensayista y diplomático mexicano, Premio Nobel de Literatura 1990.",
            Nacionalidad = "Mexicana",
            Libros = new List<Libro>()
        }
    };
        public Autor Add(Autor autor)
        {
            autor.Id = _listaAutores.Max(p => p.Id) + 1;
            _listaAutores.Add(autor);
            return autor;
        }

        public bool Delete(int id)
        {
            var autor = _listaAutores.FirstOrDefault(p => p.Id == id);
            if (autor != null)
            {
                _listaAutores.Remove(autor);
                return true;
            }
            return false;
           
        }

        public List<Autor> GetAll()
        {
            return _listaAutores;
        }

        public Autor? GetById(int id)
        {
            var autor = _listaAutores.FirstOrDefault(p => p.Id == id);
            return autor;
            
        }

        public Autor? Update(Autor autor, int id)
        {
            var autorLista = _listaAutores.FirstOrDefault(p => p.Id == id);
            if (autorLista == null) return null;
            
            autorLista.Nombre = autor.Nombre;
            autorLista.Apellido = autor.Apellido;
            autorLista.Descripcion = autor.Descripcion;
            autorLista.Nacionalidad = autor.Nacionalidad;
            
            return autorLista;
        }
    }
}
*/