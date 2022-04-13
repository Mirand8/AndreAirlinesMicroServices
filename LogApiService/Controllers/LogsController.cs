using LogApiService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly LogService _logService;

        public LogsController(LogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Log>>> Get() => _logService.GetLogs();

        [HttpGet("{id}", Name = "GetLog")]
        public async Task<ActionResult<Log>> Get(string id)
        {
            var log = await _logService.GetLog(id);
            if (log == null) return NotFound("Log not found!");

            return Ok(log);
        }

        [HttpPost]
        public async Task<ActionResult<Log>> Create(Log log)
        {
            if (await _logService.GetLog(log.Id) != null) return BadRequest("Log already exists!");

            _logService.CreateLog(log);
            return Ok(log);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Log>> Update(string id, Log logParam)
        {
            if (await _logService.GetLog(id) == null) return NotFound("Log not found!");
            _logService.UpdateLog(id, logParam);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await _logService.GetLog(id) == null) return NotFound("Log not found!");
            _logService.DeleteLog(id);

            return NoContent();
        }
    }
}
