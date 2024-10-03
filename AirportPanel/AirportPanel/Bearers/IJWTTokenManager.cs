using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Bearers
{
    public interface IJWTTokenManager
    {
        Task<AuthResponseDTO> Authenticate(User user, string ipAdress);
        Task<AuthResponseDTO> UpdateToken(string token, string refreshToken, string ipAdress);
    }
}
