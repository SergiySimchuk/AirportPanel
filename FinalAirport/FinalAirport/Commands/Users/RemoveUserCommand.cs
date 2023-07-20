using MediatR;

namespace FinalAirport.Commands.Users
{
    public class RemoveUserCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
