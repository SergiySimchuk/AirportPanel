using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Users
{
    public class GetUserByLoginPasswordCommand : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
