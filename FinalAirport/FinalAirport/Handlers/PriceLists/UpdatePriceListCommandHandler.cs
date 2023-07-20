using AutoMapper;
using FinalAirport.Commands.PriceLists;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.PriceLists
{
    public class UpdatePriceListCommandHandler : IRequestHandler<UpdatePriceListCommand, ActionResponse>
    {
        private readonly IPriceListRepository repository;
        private readonly IMapper mapper;

        public UpdatePriceListCommandHandler(IPriceListRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(UpdatePriceListCommand request, CancellationToken cancellationToken)
        {
            var priceList = this.mapper.Map<PriceList>(request);

            try
            {
                var result = await repository.UpdatePriceList(priceList);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
