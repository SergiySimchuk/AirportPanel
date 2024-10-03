using AutoMapper;
using AirportPanel.Commands.Users;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Users
{
    public class UpdateUserCommandProfile : Profile
    {
        public UpdateUserCommandProfile()
        {
            CreateMap<UserDTO, UpdateUserCommand>();
        }
    }
}
