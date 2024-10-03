using AutoMapper;
using AirportPanel.Commands.Flights;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Flights
{
    public class AddNewFlightCommandProfile : Profile
    {
        public AddNewFlightCommandProfile()
        {
            CreateMap<FlightDTO, AddNewFlightCommand>();
        }
    }
}
