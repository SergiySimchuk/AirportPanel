namespace FinalAirport.DTO
{
    public class FlightStatusDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SecondsTo { get; set; }
        public bool Arrival { get; set; }
        public string RelatedTo 
        {
            get => Arrival ? "Arrival" : "Departure";
        }
    }
}
