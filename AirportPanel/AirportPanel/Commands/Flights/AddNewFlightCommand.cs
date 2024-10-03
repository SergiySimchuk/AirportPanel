using MediatR;

namespace AirportPanel.Commands.Flights
{
    public class AddNewFlightCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public int DepartureTerminalID { get; set; }
        public int ArrivalTerminalID { get; set; }
        public int DepartureGateId { get; set; }
        public int ArrivalGateId { get; set; }
    }
}
