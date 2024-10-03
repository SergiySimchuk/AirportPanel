using AirportPanel.Commands.FlightStatuses;
using AirportPanel.Domain;
using MediatR;
using AirportPanel.Infrastructure;
using AirportPanel.Infrastructure.Abstracts;

namespace AirportPanel.Handlers.FlightStatuses
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
