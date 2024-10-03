using MediatR;

namespace AirportPanel.Commands.Flights
{
    public class RemoveFlightCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
