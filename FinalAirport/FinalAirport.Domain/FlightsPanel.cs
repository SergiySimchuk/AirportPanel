using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalAirport.Domain;

namespace FinalAirport.Domain
{
    [Table("FlightsDataView")]
    public class FlightsPanel
    {
        public int ID { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public int DepartureAirportID { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureCountry { get; set; }
        public int ArrivalAirportID { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalCity { get; set; }
        public string ArrivalCountry { get; set; }
        public int DepartureTerminalID { get; set; }
        public int ArrivalTerminalID { get; set; }
        public string DepartureTerminal { get; set; }
        public string ArrivalTerminal { get; set; }
        public int DepartureGateID { get; set; }
        public int ArrivalGateID { get; set; }
        public string DepartureGate { get; set; }
        public string ArrivalGate { get; set; }
        public int StatusID { get; set; }
        public string FlightStatus { get; set; }
    }
}