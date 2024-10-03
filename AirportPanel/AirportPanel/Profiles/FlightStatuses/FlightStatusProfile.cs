using AutoMapper;
using AirportPanel.Commands.FlightStatuses;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.FlightStatuses
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
