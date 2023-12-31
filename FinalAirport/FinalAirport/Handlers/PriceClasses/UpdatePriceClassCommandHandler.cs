﻿using AutoMapper;
using FinalAirport.Commands.PriceClasses;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.PriceClasses
{
    public class UpdatePriceClassCommandHandler : IRequestHandler<UpdatePriceClassCommand, ActionResponse>
    {
        private readonly IPriceClassesRepository repository;
        private readonly IMapper mapper;

        public UpdatePriceClassCommandHandler(IPriceClassesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(UpdatePriceClassCommand request, CancellationToken cancellationToken)
        {
            var priceClass = this.mapper.Map<PriceClass>(request);

            try
            {
                var result = await repository.UpdatePriceClass(priceClass);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
