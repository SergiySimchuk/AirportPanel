using AutoMapper;
using AirportPanel.Commands.Airports;
using AirportPanel.Commands.Terminals;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.Airports
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<AddNewAirportCommand, Airport>();
            CreateMap<UpdateAirportCommand, Airport>();
            CreateMap<RemoveAirportCommand, Airport>();
            CreateMap<GetTerminalsByAirportCommand, Airport>();
        }
    }
}
