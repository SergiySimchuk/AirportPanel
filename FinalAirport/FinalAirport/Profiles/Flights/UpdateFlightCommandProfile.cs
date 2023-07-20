using AutoMapper;
using FinalAirport.Commands.Flights;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Flights
{
    public class UpdateFlightCommandProfile : Profile
    {
        public UpdateFlightCommandProfile()
        {
            CreateMap<FlightDTO, UpdateFlightCommand>();
        }
    }
}

