using AutoMapper;
using AutoMapper.Configuration;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Tickets
{
    public class TicketDTOProfile : Profile
    {
        public TicketDTOProfile()
        {
            CreateMap<Ticket, TicketDTO>()
                .ForMember(dest => dest.FlightNumber, act => act.MapFrom(dest => dest.Flight.FlightNumber))
                    .ForMember(dest => dest.PriceClass, act => act.MapFrom(dest => dest.PriceClass.Name))
                    .ForMember(dest => dest.PassengerFirstName, act => act.MapFrom(dest => dest.Passenger.FirstName))
                    .ForMember(dest => dest.PassengerLastName, act => act.MapFrom(dest => dest.Passenger.LastName))
                    .ForMember(dest => dest.PassengerPassport, act => act.MapFrom(dest => dest.Passenger.Passport))
                    .ForMember(dest => dest.PassengerGender, act => act.MapFrom(dest => dest.Passenger.Gender))
                    .ForMember(dest => dest.PassengerDateOfBirth, act => act.MapFrom(dest => dest.Passenger.DateOfBirth))
                    .ForMember(dest => dest.PassengerNationality, act => act.MapFrom(dest => dest.Passenger.Nationality));
        }
    }
}
