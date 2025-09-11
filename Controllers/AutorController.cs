using System.Security;
using Bibliote.Interface;
using Bibliote.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly IAutorService _autorService;

    public AutoresController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    [HttpGet]
    public ActionResult<List<Autor>> GetAll()
    {
        return Ok(_autorService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Autor> GetByID(int id)
    {
        return Ok(_autorService.GetById(id));
    }

    [HttpPost]
    public ActionResult<Autor> Create([FromBody] Autor autor)
    {
        autor = _autorService.Add(autor);
        return CreatedAtAction(nameof(GetByID), new { id = autor.Id }, autor);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var p = _autorService.GetById(id);

        
        if (p != null)
        {
            _autorService.Delete(id);
            return NoContent();
        }
        else
        {
            return NotFound($"No se encontro la autor con ID {id}");
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Autor> Actualizar([FromBody] Autor autor, int id)
    {
        var p = _autorService.Update(autor, id);
        return Ok(p);
    }
}


