using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Flights
{
    public class GetFlightByIDCommand : IRequest<Flight>
    {
        public int Id { get; set; }
    }
}
