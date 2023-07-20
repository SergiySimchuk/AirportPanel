using AutoMapper;
using FinalAirport.Commands.FlightStatuses;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.FlightStatuses
{
    public class UpdateFlifgtStatusCommandProfile : Profile
    {
        public UpdateFlifgtStatusCommandProfile()
        {
            CreateMap<FlightStatusDTO, UpdateFlifgtStatusCommand>();
        }
    }
}
