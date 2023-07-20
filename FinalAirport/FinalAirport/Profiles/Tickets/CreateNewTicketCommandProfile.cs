using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Tickets
{
    public class CreateNewTicketCommandProfile : Profile
    {
        public CreateNewTicketCommandProfile()
        {
            CreateMap<TicketDTO, CreateTicketCommand>();
        }
    }
}
