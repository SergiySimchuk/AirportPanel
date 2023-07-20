using FinalAirport.Domain;
using MediatR;
namespace FinalAirport.Handlers.Users
{
    public class GetUserByLoginPasswordStaffCommand : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Staff { get; set; }
    }
}
