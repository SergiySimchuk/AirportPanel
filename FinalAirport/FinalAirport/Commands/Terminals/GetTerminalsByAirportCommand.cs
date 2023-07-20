using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Terminals
{
    public class GetTerminalsByAirportCommand : IRequest<ICollection<Terminal>>
    {
        public int Id { get; set; }
    }
}
