using Bibliote.Models;

namespace Bibliote.Interface
{
    public interface IAutorService
    {
        List<Autor> GetAll();
        Autor GetById(int id);

        Autor Update(Autor autor, int id);

        void Delete(int id);

        Autor Add(Autor autor);

    }
}