using FinalAirport.Domain;
using MediatR;
namespace FinalAirport.Commands.Airports
{
    public class GetAirportsCommand : IRequest<ICollection<Airport>>
    {
    }
}
