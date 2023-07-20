namespace FinalAirport.DTO
{
    public class GateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TerminalID { get; set; }
        public string TerminalName { get; set; }

        public int AirportID { get; set; }
        public string AirportName { get; set; }
    }
}
