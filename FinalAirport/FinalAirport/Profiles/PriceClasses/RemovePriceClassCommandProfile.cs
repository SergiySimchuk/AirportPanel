using AutoMapper;
using FinalAirport.Commands.PriceClasses;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.PriceClasses
{
    public class RemovePriceClassCommandProfile : Profile
    {
        public RemovePriceClassCommandProfile()
        {
            CreateMap<PriceClassDTO, RemovePriceClassCommand>();
        }
    }
}
