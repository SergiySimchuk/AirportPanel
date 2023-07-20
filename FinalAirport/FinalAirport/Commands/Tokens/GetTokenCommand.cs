using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Tokens
{
    public class GetTokenCommand : IRequest<JWTToken>
    {
        public string Token { get; set; }
    }
}
