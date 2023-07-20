using AutoMapper;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.PriceClasses
{
    public class PriceClassDTOProfile : Profile
    {
        public PriceClassDTOProfile()
        {
            CreateMap<PriceClass, PriceClassDTO>();
        }
    }
}
