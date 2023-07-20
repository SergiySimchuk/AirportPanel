using FinalAirport.Commands.Users;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Users
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
