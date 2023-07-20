using AutoMapper;
using FinalAirport.Commands.Flights;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Flights
{
    public class RemoveFlightCommandProfile : Profile
    {
        public RemoveFlightCommandProfile()
        {
            CreateMap<FlightDTO, RemoveFlightCommand>();
        }
    }
}
