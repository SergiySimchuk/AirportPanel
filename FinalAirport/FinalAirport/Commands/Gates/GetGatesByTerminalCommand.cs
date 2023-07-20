using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Gates
{
    public class GetGatesByTerminalCommand : IRequest<ICollection<Gate>>
    {
        public int Id { get; set; }
    }
}
