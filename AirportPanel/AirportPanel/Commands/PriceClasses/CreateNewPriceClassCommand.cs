using MediatR;

namespace AirportPanel.Commands.PriceClasses
{
    public class CreatePriceClassCommand : IRequest<ActionResponse>
    {
        public string Name { get; set; }    
    }
}
