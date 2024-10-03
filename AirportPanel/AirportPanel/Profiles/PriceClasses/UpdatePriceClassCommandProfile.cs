using AutoMapper;
using AirportPanel.Commands.PriceClasses;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.PriceClasses
{
    public class UpdatePriceClassCommandProfile : Profile
    {
        public UpdatePriceClassCommandProfile()
        {
            CreateMap<PriceClassDTO, UpdatePriceClassCommand>();
        }
    }
}
