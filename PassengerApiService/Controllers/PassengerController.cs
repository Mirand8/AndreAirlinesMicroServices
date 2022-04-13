using PassengerApiService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using ModelsLib.DataValidations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PassengerApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerService _passengerService;

        public PassengerController(PassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Passenger>>> Get() => _passengerService.GetPassengers();

        [HttpGet("{cpf:length(11)}", Name = "GetPassenger")]
        public async Task<ActionResult<Passenger>> Get(string cpf)
        {
            if (!PersonDataValidation.IsCpfValid(cpf)) return BadRequest("CPF inválido");
            var passenger = await _passengerService.GetPassenger(cpf);
            if (passenger == null) return NotFound("Pessoa nao encontrada!");

            return Ok(passenger);
        }

        [HttpPost]
        public async Task<ActionResult<Passenger>> Create(Passenger passenger)
        {
            if (!PersonDataValidation.IsCpfValid(passenger.Cpf)) return BadRequest("CPF inválido");
            else if (!PersonDataValidation.IsBithDateValid(passenger.BirthDate)) return BadRequest("Data de nascimento inválido!");
            passenger.Adress = await ViaCepService.GetViaCepAdress(passenger.Adress.Cep);
            if (passenger.Adress == null) return BadRequest("CEP não encontrado ou inválido!");

            _passengerService.CreatePassenger(passenger);
            return Ok(passenger);
        }

        [HttpPut("{cpf:length(11)}")]
        public async Task<ActionResult<Passenger>> Update(string cpf, Passenger passengerParam)
        {
            if (!PersonDataValidation.IsCpfValid(cpf)) return BadRequest("CPF inválido!");
            if (await _passengerService.GetPassenger(cpf) == null) return NotFound("Passageiro nao encontrado!");
            _passengerService.UpdatePassenger(cpf, passengerParam);

            return NoContent();
        }

        [HttpDelete("{cpf:length(11)}")]
        public async Task<IActionResult> Delete(string cpf)
        {
            if (!PersonDataValidation.IsCpfValid(cpf)) return BadRequest("CPF inválido!");
            if (await _passengerService.GetPassenger(cpf) == null) return NotFound("Pessoa nao encontrado!");

            _passengerService.DeletePassenger(cpf);

            return NoContent();
        }
    }
}
