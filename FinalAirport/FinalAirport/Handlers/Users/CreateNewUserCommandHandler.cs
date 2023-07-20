using AutoMapper;
using FinalAirport.Commands.Users;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;


namespace FinalAirport.Handlers.Users
{
    public class CreateNewUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public CreateNewUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);

            user.Password = CryptoHelper.GetStringHashSha256(user.Password);            

            try
            {
                var result = await this.repository.CreateNewUser(user);
                return user;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex) ;
            }
        }
    }
}
