using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Users
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Staff { get; set; }
    }
}
