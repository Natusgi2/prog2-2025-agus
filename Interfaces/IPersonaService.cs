using Bibliote.Models;
namespace Bibliote.Interface
{
    public interface IPersonaService
    {
        List<Persona> GetAll();
        Persona? GetById(int id);

        Persona? Update(Persona persona, int id);

        bool Delete(int id);

        Persona Add(Persona persona);

        Persona? GetByNombreUsuario(string nombreUsuario);

    }
}