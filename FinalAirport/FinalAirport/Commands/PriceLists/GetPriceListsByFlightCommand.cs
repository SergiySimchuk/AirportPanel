using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.PriceLists
{
    public class GetPriceListsByFlightCommand : IRequest<ICollection<PriceList>>
    {
        public int Id { get; set; }
    }
}
