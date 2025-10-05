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

        public Persona? GetByNombreUsuario(string nombreUsuario)
        {
            return _context.Personas.FirstOrDefault(p => p.NombreUsuario == nombreUsuario);
        }

        public bool Delete(int id)
        {
            var p = GetById(id);
            if (p == null) return false;
            _context.Personas.Remove(p);
            _context.SaveChanges();
            return true;
        }

        public List<Persona> GetAll()
        {
           return _context.Personas.ToList();
        }

        public Persona? GetById(int id)
        {
            return _context.Personas.Find(id);
        }

        public Persona? Update(Persona persona, int id)
        {
            var _persona = GetById(id);
            if (_persona == null) return null;

            _persona.Nombre = persona.Nombre;
            _persona.Apellido = persona.Apellido;
            _persona.FechaNacimiento = persona.FechaNacimiento;
            _persona.DNI = persona.DNI;
            _persona.Email = persona.Email;
            _persona.NombreUsuario = persona.NombreUsuario;
            _persona.Rol = persona.Rol;

            _context.SaveChanges();

            return _persona;
        }
    }
}