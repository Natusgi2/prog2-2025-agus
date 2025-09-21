using System.Security;
using Bibliote.Interface;
using Bibliote.Models;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<List<Persona>> GetAll()
    {
        return Ok(_personaService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Persona> GetByID(int id)
    {
        var p = _personaService.GetById(id);
        if (p == null) return NotFound($"No se encontro la persona con ID {id}");
        return Ok(p);
    }

    [HttpPost]
    public ActionResult<Persona> Create([FromBody] Persona persona)
    {
        persona = _personaService.Add(persona);
        return CreatedAtAction(nameof(GetByID), new { id = persona.Id }, persona);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        //Obtenemos el resultado de la operacion
        var result = _personaService.Delete(id);
        
        //Si el resultado es true devolvemos NoContent, sino NotFound
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


