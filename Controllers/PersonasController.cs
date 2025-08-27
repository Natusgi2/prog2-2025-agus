using Bibliote.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonasController : ControllerBase
{
    private List<Persona> _listaPersonas = new List<Persona>
    {
        new Persona {
            Id = 1,
            Nombre = "Juan",
            Apellido = "Pérez",
            FechaNacimiento = new DateTime(1995, 5, 15),
            DNI = "12345678A"
        },
        new()
        {
            Id = 2,
            Nombre = "María",
            Apellido = "Gómez",
            FechaNacimiento = new DateTime(2000, 8, 20),
            DNI = "87654321B"
        },
        new ()
        {
            Id = 3,
            Nombre = "Carlos",
            Apellido = "Rodríguez",
            FechaNacimiento = new DateTime(1980, 1, 10),
            DNI = "98765432C"
        },
        new ()
        {
            Id = 4,
            Nombre = "Ana",
            Apellido = "López",
            FechaNacimiento = new DateTime(1998, 11, 25),
            DNI = "56789012D"
        },
        new ()
        {
            Id = 5,
            Nombre = "Sofía",
            Apellido = "Martínez",
            FechaNacimiento = new DateTime(1990, 7, 30),
            DNI = "23456789E"
        }
    };

    [HttpGet]
    public ActionResult<List<Persona>> GetAll()
    {
        return Ok(_listaPersonas);
    }

    [HttpGet("{id}")]
    public ActionResult<Persona> GetByID(int id)
    {
        return Ok(_listaPersonas.FirstOrDefault(p => p.Id == id));
    }

    [HttpPost]
    public ActionResult<Persona> Create([FromBody] Persona persona)
    {
        int lastId = _listaPersonas.Max(p => p.Id);
        persona.Id = lastId + 1;

        _listaPersonas.Add(persona);
        return CreatedAtAction(nameof(GetByID), new { id = persona.Id }, persona);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var p = _listaPersonas.FirstOrDefault(p => p.Id == id);
        bool result = _listaPersonas.Remove(p);
        if (result)
        {
            return NoContent();
        }
        else
        {
            return NotFound($"No se encontro la persona con ID {id}");
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Persona> Actualizar([FromBody] Persona persona, int id)
    {
        var p = _listaPersonas.FirstOrDefault(p => p.Id == id);

        p.Nombre = persona.Nombre;
        p.Apellido = persona.Apellido;
        p.DNI = persona.DNI;
        p.FechaNacimiento = persona.FechaNacimiento;

        return Ok(p);
    }
}


