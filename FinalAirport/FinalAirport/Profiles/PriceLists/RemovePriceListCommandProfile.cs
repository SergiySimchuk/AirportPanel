using AutoMapper;
using FinalAirport.Commands.PriceLists;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.PriceLists
{
    public class RemovePriceListCommandProfile: Profile
    {
        public RemovePriceListCommandProfile()
        {
            CreateMap<PriceListDTO, RemovePriceListCommand>();
        }
    }
}
