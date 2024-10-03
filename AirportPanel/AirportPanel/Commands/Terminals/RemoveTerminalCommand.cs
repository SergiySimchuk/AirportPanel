using MediatR;

namespace AirportPanel.Commands.Terminals
{
    public class RemoveTerminalCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
