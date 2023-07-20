using AutoMapper;
using FinalAirport.Commands.PriceClasses;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.PriceClasses
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
