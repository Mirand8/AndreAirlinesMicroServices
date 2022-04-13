using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using ModelsLib.DataValidations;
using System.Threading.Tasks;
using TicketApiService.Services;

namespace TicketApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        readonly TicketService _ticketsService;

        public TicketsController(TicketService ticketService)
        {
            _ticketsService = ticketService;
        }

        [HttpGet("{id}", Name = "GetTicket")]
        public async Task<ActionResult<Ticket>> Get(string id)
        {
            var ticket = await _ticketsService.GetTicket(id);

            if (ticket == null) return BadRequest("Passagem não encontrada!");

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> Create(Ticket ticket)
        {
            if (!PersonDataValidation.IsCpfValid(ticket.Passenger.Cpf)) return BadRequest("Cpf inválido");
            var passenger = await PassengerService.GetPassenger(ticket.Passenger.Cpf);
            var @class = await ClassService.GetClass(ticket.Class.Id);
            var flight = await FlightService.GetFlight(ticket.Flight.Id);

            if (passenger == null) return BadRequest("Passageiro não encontrado");
            if (@class == null) return BadRequest("Classe não existe");
            if (flight == null) return BadRequest("Voo não encontrado");
            if (await _ticketsService.GetTicket(ticket.Id) == null) return BadRequest("A passagem ja existe!");

            ticket.Passenger =  passenger;
            ticket.Class =  @class;
            ticket.Flight = flight;

            _ticketsService.CreateTicket(ticket);
            return Ok(ticket);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ticket>> Update(string id, Ticket ticket)
        {
            if (await _ticketsService.GetTicket(ticket.Id) == null) return NotFound("A passagem não existe");
            _ticketsService.UpdateTicket(id, ticket);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> Delete(string id)
        {
            if (await _ticketsService.GetTicket(id) == null) return NotFound("A passagem não existe");
            _ticketsService.DeleteTicket(id);

            return NoContent();
        }
    }
}
