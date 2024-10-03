using AirportPanel.Commands.Passengers;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Passengers
{
    public class GetAllPassengersCommandHandler : IRequestHandler<GetAllPassengersCommand, ICollection<Passenger>>
    {
        private readonly IPassengerRepository repository;

        public GetAllPassengersCommandHandler(IPassengerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ICollection<Passenger>> Handle(GetAllPassengersCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.GetAll();
        }
    }
}
