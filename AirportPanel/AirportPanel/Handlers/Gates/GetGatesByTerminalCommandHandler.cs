using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Gates
{
    public class GetGatesByTerminalCommandHandler : IRequestHandler<GetGatesByTerminalCommand, ICollection<Gate>>
    {
        private readonly IGatesRepository repository;
        private readonly IMapper mapper;

        public GetGatesByTerminalCommandHandler(IGatesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task<ICollection<Gate>> Handle(GetGatesByTerminalCommand request, CancellationToken cancellationToken)
        {
            var terminal = this.mapper.Map<Terminal>(request);

            return this.repository.GetGatesByTerminal(terminal);
        }
    }
}
