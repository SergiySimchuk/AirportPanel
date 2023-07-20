using AutoMapper;
using FinalAirport.DTO;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.PriceLists
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
