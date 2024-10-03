namespace AirportPanel.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int PriceClassId { get; set; }
        public decimal Price { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public string PriceClass{ get; set; }
        public string FlightNumber { get; set; }
        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }
        public string PassengerNationality { get; set; }
        public string PassengerGender { get; set; }
        public string PassengerPassport{ get; set; }
        public DateTime PassengerDateOfBirth { get; set; }
    }
}
