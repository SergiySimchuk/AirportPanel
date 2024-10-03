using AutoMapper;
using AirportPanel.Commands.Flights;
using AirportPanel.Domain;
using AirportPanel.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportPanel.Controllers
{
    [Authorize]
    public class FlightsController : Controller
    {
        private IMediator mediator;
        private IMapper mapper;

        public FlightsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await mediator.Send(new GetFlightsPanelCommand());
            var flightsDTO =  flights.Select(flightPanel => this.mapper.Map<FlightPanelDTO>(flightPanel));
            return Ok(flightsDTO);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetFlightsByConditions([FromBody] FlightSearchConditions conditions)
        {
            var command = this.mapper.Map<GetFlightPanelBySearchConditionsCommand>(conditions);

            var flightsPanel = await this.mediator.Send(command);

            var flightsPanelDTO = flightsPanel.Select(flightPanel => this.mapper.Map<FlightPanelDTO>(flightPanel));

            return Ok(flightsPanelDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewFlight([FromBody] FlightDTO flight)
        {
            var command = this.mapper.Map<AddNewFlightCommand>(flight);
            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetFlightByID([FromQuery] int id)
        {
            var comand = new GetFlightByIDCommand() { Id = id };

            var flight = await this.mediator.Send(comand);

            var flihtDTO = this.mapper.Map<FlightDTO>(flight);

            return Ok(flihtDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFlight([FromBody] FlightDTO flight)
        {
            var command = this.mapper.Map<RemoveFlightCommand>(flight);
            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFlight([FromBody] FlightDTO flight)
        {
            var command = this.mapper.Map<UpdateFlightCommand>(flight);
            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetFlightPanelByID([FromQuery] int id)
        {
            var flightPanel = await this.mediator.Send(new GetFlightPanelByIDCommand() { Id = id });

            var result = this.mapper.Map<FlightPanelDTO>(flightPanel);
            return Ok(result);
        }
    }
}
