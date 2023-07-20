using MediatR;

namespace FinalAirport.Commands.Flights
{
    public class RemoveFlightCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
