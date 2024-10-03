using AutoMapper;
using AirportPanel.Commands.FlightStatuses;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.FlightStatuses
{
    public class UpdateFlifgtStatusCommandProfile : Profile
    {
        public UpdateFlifgtStatusCommandProfile()
        {
            CreateMap<FlightStatusDTO, UpdateFlifgtStatusCommand>();
        }
    }
}
