using MediatR;

namespace AirportPanel.Commands.Users
{
    public class CheckUserLoginAlreadyExistCommand : IRequest<bool> 
    {
        public string Login { get; set; }
    }
}
