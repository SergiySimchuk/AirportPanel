using MediatR;

namespace FinalAirport.Commands.PriceLists
{
    public class RemovePriceListCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
