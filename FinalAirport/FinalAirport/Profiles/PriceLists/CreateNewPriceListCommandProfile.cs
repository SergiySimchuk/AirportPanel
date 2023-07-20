using AutoMapper;
using FinalAirport.Commands.Prices;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.PriceLists
{
    public class CreateNewPriceListCommandProfile : Profile
    {
        public CreateNewPriceListCommandProfile()
        {
            CreateMap<PriceListDTO, CreatePriceListCommand>();
        }
    }
}
