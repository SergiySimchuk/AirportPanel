using AutoMapper;
using AirportPanel.Commands.Users;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Users
{
    public class RemoveUserCommandProfile : Profile
    {
        public RemoveUserCommandProfile()
        {
            CreateMap<UserDTO, RemoveUserCommand>();
        }
    }
}
