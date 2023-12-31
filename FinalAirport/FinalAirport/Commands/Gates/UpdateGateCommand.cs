﻿using MediatR;

namespace FinalAirport.Commands.Gates
{
    public class UpdateGateCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TerminalId { get; set; }
    }
}
