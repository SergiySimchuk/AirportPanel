using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Bearers
{
    public interface IJWTTokenManager
    {
        Task<AuthResponseDTO> Authenticate(User user, string ipAdress);
        Task<AuthResponseDTO> UpdateToken(string token, string refreshToken, string ipAdress);
    }
}
