using AutoMapper;
using FinalAirport.Commands.PriceClasses;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.PriceClasses
{
    public class UpdatePriceClassCommandProfile : Profile
    {
        public UpdatePriceClassCommandProfile()
        {
            CreateMap<PriceClassDTO, UpdatePriceClassCommand>();
        }
    }
}
