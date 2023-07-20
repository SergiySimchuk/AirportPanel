namespace FinalAirport.DTO
{
    public class PassengerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
