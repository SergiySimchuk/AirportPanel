using AutoMapper;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Terminals
{
    public class TerminalDTOProfile : Profile
    {
        public TerminalDTOProfile()
        {
            CreateMap<Terminal, TerminalDto>()
                    .ForMember(dest => dest.AirportName, act => act.MapFrom(src => src.Airport.Name));
        }
    }
}
