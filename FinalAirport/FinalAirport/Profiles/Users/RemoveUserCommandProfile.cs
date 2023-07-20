using AutoMapper;
using FinalAirport.Commands.Users;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Users
{
    public class RemoveUserCommandProfile : Profile
    {
        public RemoveUserCommandProfile()
        {
            CreateMap<UserDTO, RemoveUserCommand>();
        }
    }
}
