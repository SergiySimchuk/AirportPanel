using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.PriceLists
{
    public class GetPriceListsByFlightCommand : IRequest<ICollection<PriceList>>
    {
        public int Id { get; set; }
    }
}
