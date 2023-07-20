using AutoMapper;
using FinalAirport.Commands.Users;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Users
{
    public class UpdateUserCommandProfile : Profile
    {
        public UpdateUserCommandProfile()
        {
            CreateMap<UserDTO, UpdateUserCommand>();
        }
    }
}
