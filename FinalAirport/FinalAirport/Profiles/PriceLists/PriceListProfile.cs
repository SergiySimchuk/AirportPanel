using AutoMapper;
using AutoMapper.Configuration;
using FinalAirport.Commands.PriceLists;
using FinalAirport.Commands.Prices;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.PriceLists
{
    public class PriceListProfile : Profile
    {
        public PriceListProfile()
        {
            CreateMap<CreatePriceListCommand, PriceList>();
            CreateMap<UpdatePriceListCommand, PriceList>();
            CreateMap<RemovePriceListCommand, PriceList>();
        }
    }
}
