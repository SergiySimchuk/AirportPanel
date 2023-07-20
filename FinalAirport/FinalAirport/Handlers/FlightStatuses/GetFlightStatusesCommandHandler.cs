using FinalAirport.Commands.FlightStatuses;
using FinalAirport.Domain;
using MediatR;
using FinalAirport.Infrastructure;
using FinalAirport.Infrastructure.Abstracts;

namespace FinalAirport.Handlers.FlightStatuses
{
    public class GetFlightStatusesCommandhandler : IRequestHandler<GetFlightStatusesCommand, ICollection<FlightStatus>>
    {
        private readonly IFlightStatusRepository repository;

        public GetFlightStatusesCommandhandler(IFlightStatusRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<FlightStatus>> Handle(GetFlightStatusesCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.GetAll();
        }
    }
}
