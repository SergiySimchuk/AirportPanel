using AirportPanel.Commands.Flights;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Flights
{
    public class GetFlightByIDCommandHandler : IRequestHandler<GetFlightByIDCommand, Flight>
    {
        public readonly IFlightRepository repository;

        public GetFlightByIDCommandHandler(IFlightRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Flight> Handle(GetFlightByIDCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.GetFlightById(request.Id);
        }
    }
}
