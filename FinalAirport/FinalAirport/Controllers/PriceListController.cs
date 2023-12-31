﻿using AutoMapper;
using FinalAirport.Commands.PriceLists;
using FinalAirport.Commands.Prices;
using FinalAirport.Domain;
using FinalAirport.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace FinalAirport.Controllers
{
    [Authorize]
    public class PriceListController : Controller
    {
        private IMediator mediator;
        private IMapper mapper;

        public PriceListController(IMediator mediator,  IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPriceListByFlight([FromQuery] int flightId)
        {
            var command = new GetPriceListsByFlightCommand() { Id = flightId };

            var priceList = await this.mediator.Send(command);

            var result = priceList.Select(priseListEntity=>this.mapper.Map<PriceListDTO>(priseListEntity));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPrice([FromBody] PriceListDTO price)
        {
            var command = this.mapper.Map<CreatePriceListCommand>(price);
            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePrice([FromBody] PriceListDTO price)
        {
            var command = this.mapper.Map<UpdatePriceListCommand>(price);
            
            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePrice([FromBody] PriceListDTO price)
        {
            var command = this.mapper.Map<RemovePriceListCommand>(price);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }
    }
}
