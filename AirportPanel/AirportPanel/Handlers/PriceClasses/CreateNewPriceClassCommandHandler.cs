using AutoMapper;
using AirportPanel.Commands.PriceClasses;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.PriceClasses
{
    public class CreateNewPriceClassCommandHandler : IRequestHandler<CreatePriceClassCommand, ActionResponse>
    {
        private readonly IPriceClassesRepository repository;
        private readonly IMapper mapper;
        public CreateNewPriceClassCommandHandler(IPriceClassesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(CreatePriceClassCommand request, CancellationToken cancellationToken)
        {
            var priceClass = this.mapper.Map<PriceClass>(request);

            try
            {
                var result = await repository.CreateNewPriceClass(priceClass);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
