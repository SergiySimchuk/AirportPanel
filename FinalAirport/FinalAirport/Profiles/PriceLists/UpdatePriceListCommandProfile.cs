using AutoMapper;
using FinalAirport.Commands.PriceLists;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.PriceLists
{
    public class UpdatePriceListCommandProfile : Profile
    {
        public UpdatePriceListCommandProfile()
        {
            CreateMap<PriceListDTO, UpdatePriceListCommand>();
        }
    }
}
