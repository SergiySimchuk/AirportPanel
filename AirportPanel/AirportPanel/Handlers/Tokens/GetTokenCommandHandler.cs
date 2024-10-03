using AirportPanel.Commands.Tokens;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Tokens
{
    public class GetTokenCommandHandler : IRequestHandler<GetTokenCommand, JWTToken>
    {
        private readonly ITokensRepository tokensRepository;

        public GetTokenCommandHandler(ITokensRepository tokensRepository)
        {
            this.tokensRepository = tokensRepository;
        }

        public async Task<JWTToken> Handle(GetTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenModel = this.tokensRepository.GetToken(request.Token);

            return await tokenModel;
        }
    }
}
