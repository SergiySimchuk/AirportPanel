using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Flights
{
    public class GetFlightsPanelCommand : IRequest<ICollection<FlightsPanel>>
    {

    }
}