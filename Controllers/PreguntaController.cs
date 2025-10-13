using Bibliote.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Bibliote.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PreguntaController : ControllerBase
    {
        private IPreguntaService _preguntaService;

        public PreguntaController(IPreguntaService preguntaService)
        {
            _preguntaService = preguntaService;
        }

         [HttpGet]
    public async Task<ActionResult<List<Pregunta>>> Get()
    {
        var questions = await _preguntaService.GetPreguntasAsync();
        if (questions == null || questions.Count == 0)
        {
            return NotFound();
        }
        return Ok(questions);
    }



        
    }
}