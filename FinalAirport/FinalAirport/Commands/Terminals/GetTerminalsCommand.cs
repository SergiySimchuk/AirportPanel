using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Terminals
{
    public class GetTerminalsCommand : IRequest<ICollection<Terminal>>
    {
    }
}
