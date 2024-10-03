using AutoMapper;
using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Users
{
    public class UserDTOProfile : Profile
    {
        public UserDTOProfile()
        {
            CreateMap<User, UserDTO>().ForMember(destination=>destination.Password, action=>action.MapFrom(source=>string.Empty));
        }
    }
}
