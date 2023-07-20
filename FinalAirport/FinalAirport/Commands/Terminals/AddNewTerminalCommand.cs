using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Terminals
{
    public class AddNewTerminalCommand : IRequest<ActionResponse>
    {
        public string Name { get; set; }
        public int AirportId { get; set; }
    }
}
