using AutoMapper;
using FinalAirport.Commands.Terminals;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Terminals
{
    public class GetTerminalsByAirportCommandProfile : Profile
    {
        public GetTerminalsByAirportCommandProfile()
        {
            CreateMap<AirportDTO, GetTerminalsByAirportCommand>();
        }
    }
}
