using FinalAirport.Commands.Passengers;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Passengers
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
