/*using Bibliote.Models;
using Bibliote.Interface;
using System.Reflection.Metadata.Ecma335;

namespace Bibliote.Services
{
    public class PersonaMemService : IPersonaService
    {
        private List<Persona> _listaPersonas = new List<Persona>
        {
        new Persona {
            Id = 1,
            Nombre = "Juan",
            Apellido = "Pérez",
            FechaNacimiento = new DateTime(1995, 5, 15),
            DNI = "12345678A",
            Email = "j.test@gmail.com"
        },
        new()
        {
            Id = 2,
            Nombre = "María",
            Apellido = "Gómez",
            FechaNacimiento = new DateTime(2000, 8, 20),
            DNI = "87654321B",
            Email = "m.test@gmail.com"
        },
        new ()
        {
            Id = 3,
            Nombre = "Carlos",
            Apellido = "Rodríguez",
            FechaNacimiento = new DateTime(1980, 1, 10),
            DNI = "98765432C",
            Email = "c.test@gmail.com"
        },
        new ()
        {
            Id = 4,
            Nombre = "Ana",
            Apellido = "López",
            FechaNacimiento = new DateTime(1998, 11, 25),
            DNI = "56789012D",
            Email = "a.test@gmail.com"
        },
        new ()
        {
            Id = 5,
            Nombre = "Sofía",
            Apellido = "Martínez",
            FechaNacimiento = new DateTime(1990, 7, 30),
            DNI = "23456789E",
            Email = "s.test@gmail.com"
        }
    };
        public Persona Add(Persona persona)
        {
            persona.Id = _listaPersonas.Max(p => p.Id) + 1;
            _listaPersonas.Add(persona);
            return persona;
        }

        public bool Delete(int id)
        {
            var persona = _listaPersonas.FirstOrDefault(p => p.Id == id);
            if (persona != null)
            {
                _listaPersonas.Remove(persona);
                return true;
            }
            return false;
           
        }

        public List<Persona> GetAll()
        {
            return _listaPersonas;
        }

        public Persona? GetById(int id)
        {
            var persona = _listaPersonas.FirstOrDefault(p => p.Id == id);
            return persona;
            
            
        }

        public Persona? Update(Persona persona, int id)
        {
            var personaLista = _listaPersonas.FirstOrDefault(p => p.Id == id);
            //Caso no se encuentre la persona
            if (personaLista == null) return null;

            //Se encontro la persona, se actualizan los datos
            personaLista.Nombre = persona.Nombre;
            personaLista.Apellido = persona.Apellido;
            personaLista.DNI = persona.DNI;
            personaLista.FechaNacimiento = persona.FechaNacimiento;

            return personaLista;
        }
    }
}
*/