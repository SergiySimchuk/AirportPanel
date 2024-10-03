using AutoMapper;
using AirportPanel.Commands.PriceLists;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.PriceLists
{
    public class RemovePriceListCommandHandler : IRequestHandler<RemovePriceListCommand, ActionResponse>
    {
        private readonly IPriceListRepository repository;
        private readonly IMapper mapper;

        public RemovePriceListCommandHandler(IPriceListRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(RemovePriceListCommand request, CancellationToken cancellationToken)
        {
            var price = this.mapper.Map<PriceList>(request);

            try
            {
                var result = await this.repository.RemovePriceList(price);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
