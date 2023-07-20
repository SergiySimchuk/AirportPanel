using AutoMapper;
using FinalAirport.Commands.PriceClasses;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.PriceClasses
{
    public class RemovePriceClassCommandHandler : IRequestHandler<RemovePriceClassCommand, ActionResponse>
    {
        private readonly IPriceClassesRepository repository;
        private readonly IMapper mapper;

        public RemovePriceClassCommandHandler(IPriceClassesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(RemovePriceClassCommand request, CancellationToken cancellationToken)
        {
            var priceClass = this.mapper.Map<PriceClass>(request);

            try
            {
                var result = await repository.RemovePriceClass(priceClass);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
