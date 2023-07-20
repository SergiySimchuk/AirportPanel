using AutoMapper;
using FinalAirport.Commands.FlightStatuses;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.FlightStatuses
{
    public class RemoveFlightStatusCommandProfile : Profile
    {
        public RemoveFlightStatusCommandProfile()
        {
            CreateMap<FlightStatusDTO, RemoveFlightStatusCommand>();
        }
    }
}
