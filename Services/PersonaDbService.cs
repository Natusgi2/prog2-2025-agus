using Bibliote.Models;
using Bibliote.Context;
using Bibliote.Interface;

namespace Bibliote.Services
{
    public class PersonaDbService : IPersonaService
    {
         private readonly BibliotecaDbContext _context;

        public PersonaDbService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public Persona Add(Persona persona)
        {
            _context.Personas.Add(persona);

            _context.SaveChanges();
            return persona;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Persona> GetAll()
        {
           return _context.Personas.ToList();
        }

        public Persona GetById(int id)
        {
            return _context.Personas.Find(id);
        }

        public Persona Update(Persona persona, int id)
        {
            throw new NotImplementedException();
        }
    }
}