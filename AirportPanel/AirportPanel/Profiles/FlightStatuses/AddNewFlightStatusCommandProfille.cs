using AutoMapper;
using AirportPanel.Commands.FlightStatuses;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.FlightStatuses
{
    public class AddNewFlightStatusCommandProfille : Profile
    {
        public AddNewFlightStatusCommandProfille()
        {
            CreateMap<FlightStatusDTO, AddNewFlightStatusCommand>();
        }
    }
}
