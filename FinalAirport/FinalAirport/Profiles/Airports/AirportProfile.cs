using AutoMapper;
using FinalAirport.Commands.Airports;
using FinalAirport.Commands.Terminals;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.Airports
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
