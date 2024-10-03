using AutoMapper;
using AirportPanel.Commands.Terminals;
using AirportPanel.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportPanel.Controllers
{
    [Authorize]
    public class TerminalsController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public TerminalsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTerminals()
        {
            var terminals = await mediator.Send(new GetTerminalsCommand());

            var terminalsDTO = terminals.Select(terminal => this.mapper.Map<TerminalDto>(terminal))
                        .OrderBy((terminal) => (terminal.AirportName, terminal.Name));

            return Ok(terminalsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTerminal([FromBody] TerminalDto terminal)
        {
            var command = this.mapper.Map<AddNewTerminalCommand>(terminal);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTerminal([FromBody] TerminalDto terminal)
        {
            var command = this.mapper.Map<RemoveTerminalCommand>(terminal);
            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTerminal([FromBody] TerminalDto terminal)
        {
            var command = this.mapper.Map<UpdateTerminalCommand>(terminal);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetTerminalsByAirport([FromBody] AirportDTO airport)
        {
            var command = this.mapper.Map<GetTerminalsByAirportCommand>(airport);
            var terminals = await this.mediator.Send(command);

            var terminalsDTO = terminals.Select(terminal => this.mapper.Map<TerminalDto>(terminal))
                        .OrderBy((terminal) => (terminal.AirportName, terminal.Name));

            return Ok(terminalsDTO);
        }
    }
}
