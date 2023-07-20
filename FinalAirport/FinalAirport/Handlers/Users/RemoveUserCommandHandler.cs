using AutoMapper;
using FinalAirport.Commands.Users;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Users
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, ActionResponse>
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public RemoveUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);

            try
            {
                var result = await this.repository.RemoveUser(user);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
