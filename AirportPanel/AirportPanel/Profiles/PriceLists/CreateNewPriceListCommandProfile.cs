using AutoMapper;
using AirportPanel.Commands.Prices;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.PriceLists
{
    public class CreateNewPriceListCommandProfile : Profile
    {
        public CreateNewPriceListCommandProfile()
        {
            CreateMap<PriceListDTO, CreatePriceListCommand>();
        }
    }
}
