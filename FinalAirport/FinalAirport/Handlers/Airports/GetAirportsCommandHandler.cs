using MediatR;
using FinalAirport.Infrastructure;
using FinalAirport.Domain;
using FinalAirport.Commands.Airports;

namespace FinalAirport.Handlers.Airports
{
    public class GetAirportsCommandHandler : IRequestHandler<GetAirportsCommand, ICollection<Airport>>
    {
        private readonly IAirportRepository repository;

        public GetAirportsCommandHandler(IAirportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<Airport>> Handle(GetAirportsCommand request, CancellationToken cancellationToken)
        {
            return await repository.GetAll();
        }
    }
}
