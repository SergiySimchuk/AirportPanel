using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.PriceLists
{
    public class GetPriceListsByFlightOnDateCommand : IRequest<ICollection<PriceList>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
