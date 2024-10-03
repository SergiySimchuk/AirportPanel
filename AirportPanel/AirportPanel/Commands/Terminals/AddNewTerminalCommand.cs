using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Terminals
{
    public class AddNewTerminalCommand : IRequest<ActionResponse>
    {
        public string Name { get; set; }
        public int AirportId { get; set; }
    }
}
