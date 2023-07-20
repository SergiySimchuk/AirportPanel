using MediatR;

namespace FinalAirport.Commands.PriceClasses
{
    public class RemovePriceClassCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
