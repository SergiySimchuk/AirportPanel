namespace FinalAirport.DTO
{
    public class PriceListDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PriceClassID { get; set; }
        public string PriceClassName { get; set; }
        public int FlightID { get; set; }
        public decimal Price { get; set; }
    }
}
