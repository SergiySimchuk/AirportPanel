using MediatR;

namespace AirportPanel.Commands.Tickets
{
    public class CreateTicketCommand : IRequest<ActionResponse>
    {
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int PriceClassId { get; set; }
        public decimal Price { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
    }
}
