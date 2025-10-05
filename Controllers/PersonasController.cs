using System.Security;
using Bibliote.Interface;
using Bibliote.Models;
using Microsoft.AspNetCore.Mvc;
using Bibliote.Dto;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonasController : ControllerBase
{
    private readonly IPersonaService _personaService;

    public PersonasController(IPersonaService personaService)
    {
        _personaService = personaService;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<List<PersonaDto>> GetAll()
    {
        //Imprimir todas las claims en un for each
        foreach (var claim in User.Claims)
        {
            Console.WriteLine(claim.Type + ": " + claim.Value);
        }

        var personas = _personaService.GetAll();
        var personasDto = personas.Select(p => new PersonaDto(p.Nombre, p.NombreUsuario, p.Apellido, p.FechaNacimiento, p.DNI)).ToList();
        return Ok(personasDto);
    }

    [HttpGet("{id}")]
    public ActionResult<PersonaDto> GetByID(int id)
    {
        var p = _personaService.GetById(id);
        if (p == null) return NotFound($"No se encontro la persona con ID {id}");
        return Ok(p);
    }

    [HttpPost]
    public ActionResult<PersonaDto> Registrar([FromBody] RegistrarPersonaDto personaDto)
    {
        var passHash = BCrypt.Net.BCrypt.HashPassword(personaDto.Contrasenia);
        var persona = new Persona
        {
            Nombre = personaDto.Nombre,
            NombreUsuario = personaDto.NombreUsuario,
            Email = personaDto.Email,
            PassHash = passHash,
            Apellido = personaDto.Apellido,
            FechaNacimiento = personaDto.FechaNacimiento,
            DNI = personaDto.DNI,
            Rol = personaDto.Rol
        };
        persona = _personaService.Add(persona);
        return CreatedAtAction(nameof(GetByID), new { id = persona.Id }, new PersonaDto(persona.Nombre, persona.NombreUsuario, persona.Apellido, persona.FechaNacimiento, persona.DNI));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _personaService.Delete(id);
        
        if (result) return NoContent();
        else return NotFound($"No se encontro la persona con ID {id}");
    }

    [HttpPut("{id}")]
    public ActionResult<Persona> Actualizar([FromBody] Persona persona, int id)
    {
        var p = _personaService.Update(persona, id);
        if (p == null) return NotFound($"No se encontro la persona con ID {id}");

        return Ok(p);
    }
}


