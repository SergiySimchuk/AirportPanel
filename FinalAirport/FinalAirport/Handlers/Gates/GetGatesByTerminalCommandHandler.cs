using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Gates
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
