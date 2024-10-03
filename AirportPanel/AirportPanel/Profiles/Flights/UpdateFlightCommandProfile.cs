using AutoMapper;
using AirportPanel.Commands.Flights;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Flights
{
    public class UpdateFlightCommandProfile : Profile
    {
        public UpdateFlightCommandProfile()
        {
            CreateMap<FlightDTO, UpdateFlightCommand>();
        }
    }
}

