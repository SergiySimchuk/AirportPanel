using AutoMapper;
using FinalAirport.Commands.Flights;
using FinalAirport.Commands.PriceLists;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.Flights
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<AddNewFlightCommand, Flight>();
            CreateMap<UpdateFlightCommand, Flight>();
            CreateMap<RemoveFlightCommand, Flight>();
            CreateMap<GetPriceListsByFlightCommand, Flight>();
            CreateMap<GetPriceListsByFlightOnDateCommand, Flight>();
        }
    }
}
