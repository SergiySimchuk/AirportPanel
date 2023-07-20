using AutoMapper;
using FinalAirport.Commands.Flights;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Flights
{
    public class AddNewFlightCommandProfile : Profile
    {
        public AddNewFlightCommandProfile()
        {
            CreateMap<FlightDTO, AddNewFlightCommand>();
        }
    }
}
