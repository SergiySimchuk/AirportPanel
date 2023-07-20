using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Tickets
{
    public class GetTicketsByConditionsCommandProfile : Profile
    {
        public GetTicketsByConditionsCommandProfile()
        {
            CreateMap<TicketSearchConditions, GetTicketsByConditionsCommand>();
        }
    }
}
