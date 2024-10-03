using MediatR;

namespace AirportPanel.Commands.PriceClasses
{
    public class UpdatePriceClassCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
