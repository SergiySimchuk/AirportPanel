using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Terminals
{
    public class GetTerminalsByAirportCommand : IRequest<ICollection<Terminal>>
    {
        public int Id { get; set; }
    }
}
