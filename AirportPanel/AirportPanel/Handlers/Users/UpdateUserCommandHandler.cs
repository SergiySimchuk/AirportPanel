using AutoMapper;
using AirportPanel.Commands.Users;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ActionResponse>
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);

            try
            {
                var result = await this.repository.UpdateUser(user);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
