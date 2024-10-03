using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Flights
{
    public class GetFlightsPanelCommand : IRequest<ICollection<FlightsPanel>>
    {

    }
}