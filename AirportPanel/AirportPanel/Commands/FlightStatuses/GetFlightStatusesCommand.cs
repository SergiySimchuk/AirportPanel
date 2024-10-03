using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.FlightStatuses
{
    public class GetFlightStatusesCommand : IRequest<ICollection<FlightStatus>>
    {
    }
}
