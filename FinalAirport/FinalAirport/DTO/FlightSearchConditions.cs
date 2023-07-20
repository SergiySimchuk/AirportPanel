namespace FinalAirport.DTO
{
    public class FlightSearchConditions
    {
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
