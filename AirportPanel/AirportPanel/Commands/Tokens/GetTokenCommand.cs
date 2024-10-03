using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Tokens
{
    public class GetTokenCommand : IRequest<JWTToken>
    {
        public string Token { get; set; }
    }
}
