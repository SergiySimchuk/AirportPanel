using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Flights
{
    public class GetFlightPanelByIDCommand : IRequest<FlightsPanel>
    {
        public int Id { get; set; }
    }
}
