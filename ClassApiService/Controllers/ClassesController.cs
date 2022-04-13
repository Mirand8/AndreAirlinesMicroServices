using ClassApiService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        readonly ClassService _classService;

        public ClassesController(ClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Class>>> Get() => _classService.GetClasses();

        [HttpGet("{id}", Name = "GetClass")]
        public async Task<ActionResult<Class>> Get(string id) => await _classService.GetClass(id);

        [HttpPost]
        public async Task<ActionResult<Class>> Create(Class @class)
        {
            if (await _classService.GetClass(@class.Id) != null) return BadRequest("Esta classe ja existe na base de dados");

            _classService.CreateClass(@class);
            return Ok(@class);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Class>> Update(string id, Class @class)
        {
            if (await _classService.GetClass(id) == null) return NotFound("Classe não encontrado!");

            _classService.UpdateClass(id, @class);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await _classService.GetClass(id) == null) return BadRequest("Classe não encontrado!");

            _classService.DeleteClass(id);
            return NoContent();
        }
    }
}
