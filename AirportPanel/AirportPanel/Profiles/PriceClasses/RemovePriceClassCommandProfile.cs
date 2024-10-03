using AutoMapper;
using AirportPanel.Commands.PriceClasses;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.PriceClasses
{
    public class RemovePriceClassCommandProfile : Profile
    {
        public RemovePriceClassCommandProfile()
        {
            CreateMap<PriceClassDTO, RemovePriceClassCommand>();
        }
    }
}
