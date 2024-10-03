using AutoMapper;
using AirportPanel.Commands.PriceClasses;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.PriceClasses
{
    public class PriceClassProfile : Profile
    {
        public PriceClassProfile()
        {
            CreateMap<CreatePriceClassCommand, PriceClass>();
            CreateMap<RemovePriceClassCommand, PriceClass>();
            CreateMap<UpdatePriceClassCommand, PriceClass>();
        }
    }
}
