using MediatR;

namespace FinalAirport.Commands.FlightStatuses
{
    public class RemoveFlightStatusCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
