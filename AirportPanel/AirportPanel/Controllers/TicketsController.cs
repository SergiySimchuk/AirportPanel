using AutoMapper;
using AirportPanel.Commands.Tickets;
using AirportPanel.Domain;
using AirportPanel.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportPanel.Controllers
{
    public class TicketsController : Controller
    {
        private IMediator mediator;
        private IMapper mapper;

        public TicketsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await this.mediator.Send(new GetAllTicketsCommand());

            var ticketsDTO = tickets.Select(ticket => this.mapper.Map<TicketDTO>(ticket));

            return Ok(ticketsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> GetTicketsBySearchConditions([FromBody] TicketSearchConditions conditions)
        {
            var command = this.mapper.Map<GetTicketsByConditionsCommand>(conditions);

            var tickets = await this.mediator.Send(command);

            var ticketsDTO = tickets.Select(ticket => this.mapper.Map<TicketDTO>(ticket));

            return Ok(ticketsDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketsByUser([FromQuery] int userId)
        {
            var tickets = await this.mediator.Send(new GetTicketsByUserCommand() { Id = userId });

            var ticketsDTO = tickets.Select(ticket => this.mapper.Map<TicketDTO>(ticket));

            return Ok(ticketsDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketsByPassenger([FromQuery] int passengerId)
        {
            var tickets = await this.mediator.Send(new GetTicketsByPassengerCommand() { Id = passengerId });

            var ticketsDTO = tickets.Select(ticket => this.mapper.Map<TicketDTO>(ticket));

            return Ok(ticketsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTicket([FromBody] TicketDTO ticket)
        {
            var command = this.mapper.Map<CreateTicketCommand>(ticket);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTicket([FromBody] TicketDTO ticket)
        {
            var command = this.mapper.Map<UpdateTicketCommand>(ticket);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTicket([FromBody] TicketDTO ticket)
        {
            var command = this.mapper.Map<RemoveTicketCommand>(ticket);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }
    }
}
