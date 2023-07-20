using AutoMapper;
using FinalAirport.Commands.Airports;
using FinalAirport.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAirport.Controllers
{
    [Authorize]
    public class AirportsController : Controller
    {
        private IMediator mediator;
        private readonly IMapper mapper;

        public AirportsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirports()
        {
            var airports = await this.mediator.Send(new GetAirportsCommand());
            var airportsDto = airports.Select(airport => this.mapper.Map<AirportDTO>(airport));

            return Ok(airportsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewAirport([FromBody] AirportDTO airport)
        {
            var command = this.mapper.Map<AddNewAirportCommand>(airport);

            var addingResult = await mediator.Send(command);

            return Ok(addingResult);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAirport([FromBody] AirportDTO airport)
        {
            var command = this.mapper.Map<RemoveAirportCommand>(airport);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAirport([FromBody] AirportDTO airport)
        {
            var command = this.mapper.Map<UpdateAirportCommand>(airport);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }
    }
}
