using AutoMapper;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Passengers
{
    public class PassengerDTOProfile : Profile
    {
        public PassengerDTOProfile()
        {
            CreateMap<Passenger, PassengerDTO>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => (src.User == null ? "no user" : src.User.Login)));
        }
    }
}
