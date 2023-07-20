using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Tickets
{
    public class UpdateTicketCommandProfile : Profile
    {
        public UpdateTicketCommandProfile()
        {
            CreateMap<TicketDTO, UpdateTicketCommand>();
        }
    }
}
