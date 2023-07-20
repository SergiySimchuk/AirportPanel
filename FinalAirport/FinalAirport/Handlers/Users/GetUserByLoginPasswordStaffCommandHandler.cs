using MediatR;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using FinalAirport.Commands;

namespace FinalAirport.Handlers.Users
{
    public class GetUserByLoginPasswordStaffCommandHandler : IRequestHandler<GetUserByLoginPasswordStaffCommand, User>
    {
        private readonly IUserRepository userRepository;

        public GetUserByLoginPasswordStaffCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByLoginPasswordStaffCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = CryptoHelper.GetStringHashSha256(request.Password);

            return await userRepository.GetUserByLoginAndPassword(request.Login, hashPassword, request.Staff);
        }
    }
}
