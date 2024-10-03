using AutoMapper;
using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.PriceClasses
{
    public class PriceClassDTOProfile : Profile
    {
        public PriceClassDTOProfile()
        {
            CreateMap<PriceClass, PriceClassDTO>();
        }
    }
}
