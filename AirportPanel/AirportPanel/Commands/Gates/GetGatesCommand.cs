using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Gates
{
    public class GetGatesCommand : IRequest<ICollection<Gate>>
    {
    }
}
