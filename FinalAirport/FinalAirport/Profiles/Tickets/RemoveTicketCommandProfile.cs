using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Tickets
{
    public class RemoveTicketCommandProfile : Profile
    {
        public RemoveTicketCommandProfile()
        {
            CreateMap<TicketDTO, RemoveTicketCommand>();
        }
    }
}
