using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Flights
{
    public class GetFlightByIDCommand : IRequest<Flight>
    {
        public int Id { get; set; }
    }
}
