using AutoMapper;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Users
{
    public class UserDTOProfile : Profile
    {
        public UserDTOProfile()
        {
            CreateMap<User, UserDTO>().ForMember(destination=>destination.Password, action=>action.MapFrom(source=>string.Empty));
        }
    }
}
