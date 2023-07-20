using MediatR;

namespace FinalAirport.Commands.PriceClasses
{
    public class UpdatePriceClassCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
