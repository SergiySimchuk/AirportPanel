using MediatR;

namespace AirportPanel.Commands.FlightStatuses
{
    public class RemoveFlightStatusCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
