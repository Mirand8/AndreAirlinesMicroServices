using FlightApiService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        readonly FlightService _flightService;

        public FlightsController(FlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Flight>>> Get() => _flightService.GetFlights();

        [HttpGet("{id}", Name = "GetFlight")]
        public async Task<ActionResult<Flight>> Get(string id) => await _flightService.GetFlight(id);

        [HttpPost]
        public async Task<ActionResult<Flight>> Create(Flight flight)
        {
            var destination = await AirportService.GetAirport(flight.Destination.Id);
            var origin = await AirportService.GetAirport(flight.Origin.Id);
            var aircraft = await AircraftService.GetAircraft(flight.Aircraft.Id);

            if (destination == null) return NotFound("Aeroporto de DESTINO nao encontrado");
            if (origin == null) return NotFound("Aeroporto de ORIGEM nao encontrado");
            if (aircraft == null) return NotFound("Aeronave nao encontrada");

            flight.Aircraft = aircraft;
            flight.Destination = destination;
            flight.Origin = origin;

            _flightService.CreateFlight(flight);
            return Ok(flight);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Flight>> Update(string id, Flight flight)
        {
            if (await _flightService.GetFlight(id) == null) return NotFound("Voo não encontrado!");

            _flightService.UpdateFlight(id, flight);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await _flightService.GetFlight(id) == null) return BadRequest("Voo não encontrado!");

            _flightService.DeleteFlight(id);
            return NoContent();
        }
    }
}
