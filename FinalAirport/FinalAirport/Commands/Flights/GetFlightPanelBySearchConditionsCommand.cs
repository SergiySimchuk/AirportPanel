using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Flights
{
    public class GetFlightPanelBySearchConditionsCommand : IRequest<ICollection<FlightsPanel>>
    {
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
