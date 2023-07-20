using AutoMapper;
using FinalAirport.Commands.FlightStatuses;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.FlightStatuses
{
    public class AddNewFlightStatusCommandProfille : Profile
    {
        public AddNewFlightStatusCommandProfille()
        {
            CreateMap<FlightStatusDTO, AddNewFlightStatusCommand>();
        }
    }
}
