using AutoMapper;
using FinalAirport.Commands.Airports;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Airports
{
    public class UpdateAirportCommandProfile : Profile
    {
        public UpdateAirportCommandProfile()
        {
            CreateMap<AirportDTO, UpdateAirportCommand>();
        }
    }
}
