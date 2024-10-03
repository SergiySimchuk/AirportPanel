using AutoMapper;
using AirportPanel.Commands.PriceLists;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.PriceLists
{
    public class UpdatePriceListCommandProfile : Profile
    {
        public UpdatePriceListCommandProfile()
        {
            CreateMap<PriceListDTO, UpdatePriceListCommand>();
        }
    }
}
