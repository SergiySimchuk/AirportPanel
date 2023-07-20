using AutoMapper;
using FinalAirport.Commands.Users;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Users
{
    public class CreateNewUserCommandProfile : Profile
    {
        public CreateNewUserCommandProfile()
        {
            CreateMap<UserDTO, CreateUserCommand>();
        }
    }
}
