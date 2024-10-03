using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Gates
{
    public class GetGatesByTerminalCommand : IRequest<ICollection<Gate>>
    {
        public int Id { get; set; }
    }
}
