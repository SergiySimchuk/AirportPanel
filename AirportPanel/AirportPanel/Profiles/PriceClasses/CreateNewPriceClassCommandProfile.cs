using AutoMapper;
using AirportPanel.Commands.PriceClasses;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.PriceClasses
{
    public class CreateNewPriceClassCommandProfile : Profile
    {
        public CreateNewPriceClassCommandProfile()
        {
            CreateMap<PriceClassDTO, CreatePriceClassCommand>();
        }
    }
}
