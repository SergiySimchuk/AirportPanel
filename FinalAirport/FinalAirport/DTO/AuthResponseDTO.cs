namespace FinalAirport.DTO
{
    public class AuthResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
