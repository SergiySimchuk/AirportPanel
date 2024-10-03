using AutoMapper;
using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Gates
{
    public class GateDTOProfile : Profile 
    {
        public GateDTOProfile()
        {
            CreateMap<Gate, GateDTO>()
                .ForMember(destination => destination.TerminalName, action => action.MapFrom(source => source.Terminal.Name))
                .ForMember(destination => destination.AirportID, action => action.MapFrom(sourse => sourse.Terminal.AirportID))
                .ForMember(destination => destination.AirportName, action => action.MapFrom(source => source.Terminal.Airport.Name));
        }
    }
}
