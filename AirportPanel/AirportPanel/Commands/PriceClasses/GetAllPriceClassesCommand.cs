using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.PriceClasses
{
    public class GetAllPriceClassesCommand : IRequest<ICollection<PriceClass>>
    {
        
    }
}
