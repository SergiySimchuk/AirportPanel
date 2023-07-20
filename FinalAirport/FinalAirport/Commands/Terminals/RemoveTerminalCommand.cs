using MediatR;

namespace FinalAirport.Commands.Terminals
{
    public class RemoveTerminalCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
