using MediatR;

namespace FinalAirport.Commands.Terminals
{
    public class UpdateTerminalCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AirportId { get; set; }
    }
}
