using MediatR;

namespace FinalAirport.Commands.PriceClasses
{
    public class CreatePriceClassCommand : IRequest<ActionResponse>
    {
        public string Name { get; set; }    
    }
}
