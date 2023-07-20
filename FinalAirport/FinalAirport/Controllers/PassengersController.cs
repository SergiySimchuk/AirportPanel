using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.Domain;
using FinalAirport.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAirport.Controllers
{
   // [Authorize]
    public class PassengersController : Controller
    {
        private IMediator mediator;
        private IMapper mapper;
        public PassengersController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPassengers()
        {
            var passengers = await mediator.Send(new GetAllPassengersCommand());

            var passengersDTo = passengers.Select(passenger=> this.mapper.Map<PassengerDTO>(passenger));

            return Ok(passengersDTo);
        }

        [HttpGet]
        public async Task<IActionResult> GetPassengersByUser([FromQuery] int userId)
        {
            var command = new GetPassengersByUserCommand() { Id = userId };

            var passengers = await this.mediator.Send(command);

            var passengersDTo = passengers.Select(passenger => this.mapper.Map<PassengerDTO>(passenger));

            return Ok(passengersDTo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPassenger([FromBody] PassengerDTO passenger)
        {
            var command = this.mapper.Map<CreateNewPassengerCommand>(passenger);

            try
            {
                var domainPassenger = await this.mediator.Send(command);
                var result = this.mapper.Map<PassengerDTO>(domainPassenger);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassenger([FromBody] PassengerDTO passenger)
        {
            var command = this.mapper.Map<UpdatePassengerCommand>(passenger);

            try
            {
                var domainPassenger = await this.mediator.Send(command);

                var result = this.mapper.Map<PassengerDTO>(domainPassenger);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePassenger([FromBody] PassengerDTO passenger)
        {
            var command = this.mapper.Map<RemovePassengerCommand>(passenger);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPassengerByID([FromQuery] int id)
        {
            var command = new GetPassengerByIDCommand() { Id = id };

            var passenger = await this.mediator.Send(command);

            var passengerDto = this.mapper.Map<PassengerDTO>(passenger);

            return Ok(passengerDto);
        }
    }
}
