using AutoMapper;
using FinalAirport.Commands.Airports;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Airports
{
    public class AddNewAirportCommandProfile : Profile
    {
        public AddNewAirportCommandProfile()
        {
            CreateMap<AirportDTO, AddNewAirportCommand>();
        }
    }
}
