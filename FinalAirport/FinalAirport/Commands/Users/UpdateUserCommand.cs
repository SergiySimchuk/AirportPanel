using MediatR;

namespace FinalAirport.Commands.Users
{
    public class UpdateUserCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Staff { get; set; }
    }
}
