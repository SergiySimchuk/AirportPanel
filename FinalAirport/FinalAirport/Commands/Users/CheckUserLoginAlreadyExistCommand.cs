using MediatR;

namespace FinalAirport.Commands.Users
{
    public class CheckUserLoginAlreadyExistCommand : IRequest<bool> 
    {
        public string Login { get; set; }
    }
}
