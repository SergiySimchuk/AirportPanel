using AutoMapper;
using FinalAirport.Commands.FlightStatuses;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.FlightStatuses
{
    public class FlightStatusProfile : Profile
    {
        public FlightStatusProfile()
        {
            CreateMap<AddNewFlightStatusCommand, FlightStatus>();
            CreateMap<RemoveFlightStatusCommand, FlightStatus>();
            CreateMap<UpdateFlifgtStatusCommand, FlightStatus>();
        }
    }
}
