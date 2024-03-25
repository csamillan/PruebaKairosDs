using KairosDs.Persona;
using Microsoft.AspNetCore.Mvc;

namespace KairosDs.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService service)
        {
            _personaService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] SavePersonaDto dto)
        {
            _personaService.Save(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SavePersonaDto dto)
        {
            _personaService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personaService.Delete(id);
            return Ok();
        }
    }
}
