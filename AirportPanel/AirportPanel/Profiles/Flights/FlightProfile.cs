using AutoMapper;
using AirportPanel.Commands.Flights;
using AirportPanel.Commands.PriceLists;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.Flights
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
