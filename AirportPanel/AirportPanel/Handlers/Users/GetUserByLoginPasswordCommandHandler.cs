using AirportPanel.Commands.Users;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Users
{
    public class GetUserByLoginPasswordCommandHandler : IRequestHandler<GetUserByLoginPasswordCommand, User>
    {
        private readonly IUserRepository repository;

        public GetUserByLoginPasswordCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<User> Handle(GetUserByLoginPasswordCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = CryptoHelper.GetStringHashSha256(request.Password);

            return await this.repository.GetUserByLoginAndPassword(request.Login, hashPassword);
        }
    }
}
