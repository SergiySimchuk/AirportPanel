using AirportPanel.Commands.Flights;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Flights
{
    public class GetFlightsPanelCommandHandler : IRequestHandler<GetFlightsPanelCommand, ICollection<FlightsPanel>>
    {
        private readonly IFlightsPanelRepository repository;

        public GetFlightsPanelCommandHandler(IFlightsPanelRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ICollection<FlightsPanel>> Handle(GetFlightsPanelCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();

            return result;
        }
    }
}