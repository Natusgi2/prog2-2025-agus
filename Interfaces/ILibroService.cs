using Bibliote.Models;

namespace Bibliote.Interface
{
    public interface ILibroService
    {
        List<Libro> GetAll();
        Libro GetById(int id);

        Libro Update(Libro libro, int id);

        void Delete(int id);

        Libro Add(Libro libro);

    }
}