using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Flights
{
    public class GetFlightPanelByIDCommand : IRequest<FlightsPanel>
    {
        public int Id { get; set; }
    }
}
