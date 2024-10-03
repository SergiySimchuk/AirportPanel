using AutoMapper;
using AirportPanel.Commands.FlightStatuses;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.FlightStatuses
{
    public class RemoveFlightStatusCommandProfile : Profile
    {
        public RemoveFlightStatusCommandProfile()
        {
            CreateMap<FlightStatusDTO, RemoveFlightStatusCommand>();
        }
    }
}
