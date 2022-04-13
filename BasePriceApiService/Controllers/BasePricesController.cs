using BasePriceApiService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasePriceApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasePricesController : ControllerBase
    {
        readonly BasePriceService _basePriceService;

        public BasePricesController(BasePriceService basePriceService)
        {
            _basePriceService = basePriceService;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<BasePrice>>> Get() => _basePriceService.GetBasePrices();

        [HttpGet("{id}", Name = "GetBasePrice")]
        public async Task<ActionResult<BasePrice>> Get(string id) => await _basePriceService.GetBasePrice(id);

        [HttpPost]
        public async Task<ActionResult<BasePrice>> Create(BasePrice basePrice)
        {
            if (await _basePriceService.GetBasePrice(basePrice.Id) != null) return BadRequest("Este preco base ja existe na base de dados");

            var destination = await AirportService.GetAirport(basePrice.Destination.Id);
            var origin = await AirportService.GetAirport(basePrice.Origin.Id);

            if (destination == null) return BadRequest("O aeroporto de destino não existe");
            if (origin == null) return BadRequest("O aeroporto de origem não existe");

            basePrice.Destination = destination;
            basePrice.Origin = origin;
            basePrice.InclusionDate = System.DateTime.Now.Date;

            _basePriceService.CreateBasePrice(basePrice);
            return Ok(basePrice);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BasePrice>> Update(string id, BasePrice basePrice)
        {
            if (await _basePriceService.GetBasePrice(id) == null) return NotFound("Preco base não encontrado!");

            _basePriceService.UpdateBasePrice(id, basePrice);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await _basePriceService.GetBasePrice(id) == null) return BadRequest("Preco base não encontrado!");

            _basePriceService.DeleteBasePrice(id);
            return NoContent();
        }

    }
}
