using AutoMapper;
using FinalAirport.Commands.Airports;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Airports
{
    public class RemoveAirportCommandProfile : Profile
    {
        public RemoveAirportCommandProfile()
        {
            CreateMap<AirportDTO, RemoveAirportCommand>();
        }
    }
}
