using AutoMapper;
using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Terminals
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
