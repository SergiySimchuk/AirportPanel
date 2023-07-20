using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.PriceClasses
{
    public class GetAllPriceClassesCommand : IRequest<ICollection<PriceClass>>
    {
        
    }
}
