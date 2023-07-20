using MediatR;

namespace FinalAirport.Commands.FlightStatuses
{
    public class AddNewFlightStatusCommand : IRequest<ActionResponse>
    {
        public string Name { get; set; }
        public int SecondsTo { get; set; }
        public bool Arrival { get; set; }
    }
}
