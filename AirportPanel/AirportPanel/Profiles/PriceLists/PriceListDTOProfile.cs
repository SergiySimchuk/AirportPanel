using AutoMapper;
using AirportPanel.DTO;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.PriceLists
{
    public class PriceListDTOProfile : Profile
    {
        public PriceListDTOProfile()
        {
            CreateMap<PriceList, PriceListDTO>()
                .ForMember(destination => destination.PriceClassName, acrion => acrion.MapFrom(source => source.PriceClass.Name));
        }
    }
}
