using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.FlightStatuses
{
    public class GetFlightStatusesCommand : IRequest<ICollection<FlightStatus>>
    {
    }
}
