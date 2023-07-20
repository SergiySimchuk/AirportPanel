using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Gates
{
    public class GetGatesCommand : IRequest<ICollection<Gate>>
    {
    }
}
