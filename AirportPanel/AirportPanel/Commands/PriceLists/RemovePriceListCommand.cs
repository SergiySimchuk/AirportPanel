using MediatR;

namespace AirportPanel.Commands.PriceLists
{
    public class RemovePriceListCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
