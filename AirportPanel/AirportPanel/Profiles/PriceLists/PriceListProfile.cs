using AutoMapper;
using AutoMapper.Configuration;
using AirportPanel.Commands.PriceLists;
using AirportPanel.Commands.Prices;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.PriceLists
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
