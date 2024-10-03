using AutoMapper;
using AirportPanel.Commands.Terminals;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Terminals
{
    public class GetTerminalsbyAirportCommandHandler : IRequestHandler<GetTerminalsByAirportCommand, ICollection<Terminal>>
    {
        private readonly ITerminalRepository repository;
        private readonly IMapper mapper;

        public GetTerminalsbyAirportCommandHandler(ITerminalRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        Task<ICollection<Terminal>> IRequestHandler<GetTerminalsByAirportCommand, ICollection<Terminal>>.Handle(GetTerminalsByAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = this.mapper.Map<Airport>(request);
            return this.repository.GetTerminalsByAirport(airport);
        }
    }
}
