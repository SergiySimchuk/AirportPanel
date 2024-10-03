using AirportPanel.Commands.Passengers;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Passengers
{
    public class GetPassengerByIDCommandHandler : IRequestHandler<GetPassengerByIDCommand, Passenger>
    {
        private readonly IPassengerRepository repository;

        public GetPassengerByIDCommandHandler(IPassengerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Passenger> Handle(GetPassengerByIDCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.GetPassengerByID(request.Id);
        }
    }
}
