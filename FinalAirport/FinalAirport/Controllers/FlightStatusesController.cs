using AutoMapper;
using FinalAirport.Commands.FlightStatuses;
using FinalAirport.Domain;
using FinalAirport.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAirport.Controllers
{
    [Authorize]
    public class FlightStatusesController : Controller
    {
        private IMediator mediator;
        private IMapper mapper;

        public FlightStatusesController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlightStatuses()
        {
            var command = new GetFlightStatusesCommand();

            var flightStatuses = await this.mediator.Send(command);


            var flightStatusesDTO = flightStatuses.Select(flightStatus=> this.mapper.Map<FlightStatusDTO>(flightStatus))
                .OrderBy((flightStatus) => (flightStatus.Arrival, flightStatus.SecondsTo));

            return Ok(flightStatusesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewFlightStatus([FromBody] FlightStatusDTO flightStatus)
        {
            var command = this.mapper.Map<AddNewFlightStatusCommand>(flightStatus);
            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFlightStatus([FromBody] FlightStatusDTO flightStatus)
        {
            var command = this.mapper.Map<RemoveFlightStatusCommand>(flightStatus);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFlightStatus([FromBody] FlightStatusDTO flightStatus)
        {
            var command = this.mapper.Map<UpdateFlifgtStatusCommand>(flightStatus);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }
    }
}
