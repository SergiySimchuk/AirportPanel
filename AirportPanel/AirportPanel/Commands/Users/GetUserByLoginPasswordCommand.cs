using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Users
{
    public class GetUserByLoginPasswordCommand : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
