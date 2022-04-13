using AircraftApiService.Services;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftsController : ControllerBase
    {
        readonly AircraftService _aircraftService;

        public AircraftsController(AircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> Get() => await _aircraftService.GetAircrafts();

        [HttpGet("{id}", Name = "GetAircraft")]
        public async Task<ActionResult<Aircraft>> Get(string id)
        {
            var aircraft = await _aircraftService.GetAircraft(id);

            if (aircraft == null) return BadRequest("Aeronave não encontrada!");

            return Ok(aircraft);
        }

        [HttpPost]
        public async Task<ActionResult<Aircraft>> Create(Aircraft aircraft)
        {

            if (await _aircraftService.GetAircraft(aircraft.Id) == null) return BadRequest("Aeronave ja existe!");
            _aircraftService.CreateAircraft(aircraft);
            return Ok(aircraft);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Aircraft>> Update(string id, Aircraft aircraft)
        {
            if (await _aircraftService.GetAircraft(aircraft.Id) == null) return NotFound("A aeronave não existe");
            _aircraftService.UpdateAircraft(id, aircraft);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aircraft>> Delete(string id)
        {
            if (await _aircraftService.GetAircraft(id) == null) return NotFound("A aeronave não existe");
            _aircraftService.DeleteAircraft(id);

            return NoContent();
        }
    }
}
