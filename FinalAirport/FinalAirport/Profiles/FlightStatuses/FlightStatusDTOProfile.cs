using AutoMapper;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.FlightStatuses
{
    public class FlightStatusDTOProfile : Profile
    {
        public FlightStatusDTOProfile()
        {
            CreateMap<FlightStatus, FlightStatusDTO>();
        }
    }
}
