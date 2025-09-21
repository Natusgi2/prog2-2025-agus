using Bibliote.Interface;
using Bibliote.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly ILibroService _libroService;

    public LibrosController(ILibroService libroService)
    {
        _libroService = libroService;
    }

    [HttpGet]
    public ActionResult<List<Libro>> GetAll()
    {
        return Ok(_libroService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Libro> GetByID(int id)
    {
        return Ok(_libroService.GetById(id));
    }

    [HttpPost]
    public ActionResult<Libro> Create([FromBody] Libro libro)
    {
        libro = _libroService.Add(libro);
        return CreatedAtAction(nameof(GetByID), new { id = libro.Id }, libro);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var l = _libroService.GetById(id);

        if (l != null)
        {
            _libroService.Delete(id);
            return NoContent();
        }
        else
        {
            return NotFound($"No se encontró el libro con ID {id}");
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Libro> Actualizar([FromBody] Libro libro, int id)
    {
        var l = _libroService.Update(libro, id);
        return Ok(l);
    }
}