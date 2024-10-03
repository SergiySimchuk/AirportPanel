using MediatR;

namespace AirportPanel.Commands.Users
{
    public class RemoveUserCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
