using MediatR;

namespace AirportPanel.Commands.PriceClasses
{
    public class RemovePriceClassCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
