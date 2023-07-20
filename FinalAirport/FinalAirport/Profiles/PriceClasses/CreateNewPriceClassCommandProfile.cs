using AutoMapper;
using FinalAirport.Commands.PriceClasses;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.PriceClasses
{
    public class CreateNewPriceClassCommandProfile : Profile
    {
        public CreateNewPriceClassCommandProfile()
        {
            CreateMap<PriceClassDTO, CreatePriceClassCommand>();
        }
    }
}
