using AutoMapper;
using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.FlightStatuses
{
    public class FlightStatusDTOProfile : Profile
    {
        public FlightStatusDTOProfile()
        {
            CreateMap<FlightStatus, FlightStatusDTO>();
        }
    }
}
