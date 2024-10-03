using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAirport.ReadDataModel
{
    [Table("FlightsDataView")]
    public class Flights
    {
        [Key]
        public int FlightID { get; set; }
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
        public int TerminalID { get; set; }
        public string Terminal { get; set; }
        public int GateID { get; set; }
        public string Gate { get; set; }
        public int StatusID { get; set; }
        public string FlightStatus { get; set; }
    }
}