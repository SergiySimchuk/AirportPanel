using MediatR;

namespace FinalAirport.Commands.Tickets
{
    public class UpdateTicketCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int PriceClassId { get; set; }
        public decimal Price { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
    }
}
