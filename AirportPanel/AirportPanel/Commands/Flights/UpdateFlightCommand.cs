using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Commands.Flights
{
    public class UpdateFlightCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public int DepartureAirportID { get; set; }
        public int ArrivalAirportID { get; set; }
        public int DepartureTerminalID { get; set; }
        public int ArrivalTerminalID { get; set; }
        public int DepartureGateID { get; set; }
        public int ArrivalGateID { get; set; }
    }
}
