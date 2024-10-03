using AutoMapper;
using AirportPanel.Commands.Users;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Users
{
    public class CreateNewUserCommandProfile : Profile
    {
        public CreateNewUserCommandProfile()
        {
            CreateMap<UserDTO, CreateUserCommand>();
        }
    }
}
