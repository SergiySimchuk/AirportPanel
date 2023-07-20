using AutoMapper;
using FinalAirport.DTO;
using FinalAirport.Handlers.Users;

namespace FinalAirport.Profiles.Users
{
    public class GetUserByLoginPasswordStaffCommandProfile : Profile
    {
        public GetUserByLoginPasswordStaffCommandProfile()
        {
            CreateMap<UserDTO, GetUserByLoginPasswordStaffCommand>();
        }
    }
}
