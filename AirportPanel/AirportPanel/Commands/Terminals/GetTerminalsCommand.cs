using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Terminals
{
    public class GetTerminalsCommand : IRequest<ICollection<Terminal>>
    {
    }
}
