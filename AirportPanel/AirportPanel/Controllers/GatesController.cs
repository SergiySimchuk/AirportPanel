using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.Domain;
using AirportPanel.DTO;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportPanel.Controllers
{
    [Authorize]
    public class GatesController : Controller
    {
        private IMediator mediator;
        private IMapper mapper;

        public GatesController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGates()
        {
            var gates = await mediator.Send(new GetGatesCommand());

            var gatesDTO = gates.Select(gate=>this.mapper.Map<GateDTO>(gate))
                .OrderBy((gate) => (gate.AirportName, gate.TerminalName, gate.Name));

            return Ok(gatesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewGate([FromBody] GateDTO gate)
        {
            var command = this.mapper.Map<AddNewGateCommand>(gate);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveGate([FromBody] GateDTO gate)
        {
            var gateCommand = this.mapper.Map<RemoveGateCommand>(gate);

            var result = await this.mediator.Send(gateCommand);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGate([FromBody] GateDTO gate)
        {
            var command = this.mapper.Map<UpdateGateCommand>(gate);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetGatesByTerminal([FromBody] TerminalDto terminal)
        {

            var command = this.mapper.Map<GetGatesByTerminalCommand>(terminal);

            var gates = await this.mediator.Send(command);

            var gatesDTO = gates.Select(gate=>this.mapper.Map<GateDTO>(gate))
                .OrderBy((gate) => (gate.AirportName, gate.TerminalName, gate.Name));

            return Ok(gatesDTO);
        }
    }
}
