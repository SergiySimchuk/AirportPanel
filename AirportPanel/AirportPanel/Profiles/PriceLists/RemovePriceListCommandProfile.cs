using AutoMapper;
using AirportPanel.Commands.PriceLists;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.PriceLists
{
    public class RemovePriceListCommandProfile: Profile
    {
        public RemovePriceListCommandProfile()
        {
            CreateMap<PriceListDTO, RemovePriceListCommand>();
        }
    }
}
