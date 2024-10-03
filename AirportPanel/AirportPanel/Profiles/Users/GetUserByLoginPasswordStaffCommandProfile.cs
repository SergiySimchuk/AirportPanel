using AutoMapper;
using AirportPanel.DTO;
using AirportPanel.Handlers.Users;

namespace AirportPanel.Profiles.Users
{
    public class GetUserByLoginPasswordStaffCommandProfile : Profile
    {
        public GetUserByLoginPasswordStaffCommandProfile()
        {
            CreateMap<UserDTO, GetUserByLoginPasswordStaffCommand>();
        }
    }
}
