using AutoMapper;
using AirportPanel.Commands.Flights;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Flights
{
    public class RemoveFlightCommandProfile : Profile
    {
        public RemoveFlightCommandProfile()
        {
            CreateMap<FlightDTO, RemoveFlightCommand>();
        }
    }
}
