using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.PriceLists
{
    public class GetPriceListsByFlightOnDateCommand : IRequest<ICollection<PriceList>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
