namespace AirportPanel.DTO
{
    public class FlightPanelDTO
    {
        public int ID { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureCountry { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalCity { get; set; }
        public string ArrivalCountry { get; set; }
        public string DepartureTerminal { get; set; }
        public string ArrivalTerminal { get; set; }
        public string DepartureGate { get; set; }
        public string ArrivalGate { get; set; }
        public string FlightStatus { get; set; }
    }
}
