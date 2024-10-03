using AutoMapper;
using AirportPanel.Commands.PriceClasses;
using AirportPanel.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportPanel.Controllers
{
    [Authorize]
    public class PriceClassesController : Controller
    {
        private IMediator mediator;
        private IMapper mapper;

        public PriceClassesController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPriceClasses()
        {
            var priceClasses = await mediator.Send(new GetAllPriceClassesCommand());

            var result = priceClasses.Select(priceClass=>this.mapper.Map<PriceClassDTO>(priceClass));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPriceClass([FromBody] PriceClassDTO priceClass)
        {
            var command = this.mapper.Map<CreatePriceClassCommand>(priceClass);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePriceClass([FromBody] PriceClassDTO priceClass)
        {
            var command = this.mapper.Map<UpdatePriceClassCommand>(priceClass);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePriceClass([FromBody] PriceClassDTO priceClass)
        {
            var command = this.mapper.Map<RemovePriceClassCommand>(priceClass);
            var result = await this.mediator.Send(command);

            return Ok(result);
        }
    }
}
