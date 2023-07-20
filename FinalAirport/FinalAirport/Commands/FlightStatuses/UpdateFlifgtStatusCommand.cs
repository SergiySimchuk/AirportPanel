using MediatR;

namespace FinalAirport.Commands.FlightStatuses
{
    public class UpdateFlifgtStatusCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SecondsTo { get; set; }
        public bool Arrival { get; set; }
    }
}
