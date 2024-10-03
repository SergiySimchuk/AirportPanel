using AutoMapper;
using AirportPanel.Commands.PriceLists;
using AirportPanel.Commands.Prices;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Prices
{
    public class CreateNewPriceListCommandHandler : IRequestHandler<CreatePriceListCommand, ActionResponse>
    {
        private readonly IPriceListRepository repository;
        private readonly IMapper mapper;
        public CreateNewPriceListCommandHandler(IPriceListRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(CreatePriceListCommand request, CancellationToken cancellationToken)
        {
            var price = this.mapper.Map<PriceList>(request);

            try
            {
                var result = await this.repository.CtreateNewPriceList(price);
                return new ActionResponse() { Success = result};
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
