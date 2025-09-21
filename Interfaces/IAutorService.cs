using Bibliote.Models;

namespace Bibliote.Interface
{
    public interface IAutorService
    {
        List<Autor> GetAll();
        Autor? GetById(int id);

        Autor? Update(Autor autor, int id);

        bool Delete(int id);

        Autor Add(Autor autor);

    }
}