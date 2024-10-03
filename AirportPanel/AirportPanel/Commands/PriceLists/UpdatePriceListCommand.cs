using MediatR;

namespace AirportPanel.Commands.PriceLists
{
    public class UpdatePriceListCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PriceClassID { get; set; }
        public int FlightID { get; set; }
        public decimal Price { get; set; }
    }
}
