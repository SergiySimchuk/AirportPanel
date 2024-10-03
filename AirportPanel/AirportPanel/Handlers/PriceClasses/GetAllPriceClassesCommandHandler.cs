using AirportPanel.Commands.PriceClasses;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.PriceClasses
{
    public class GetAllPriceClassesCommandHandler : IRequestHandler<GetAllPriceClassesCommand, ICollection<PriceClass>>
    {
        private readonly IPriceClassesRepository repository;

        public GetAllPriceClassesCommandHandler(IPriceClassesRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ICollection<PriceClass>> Handle(GetAllPriceClassesCommand request, CancellationToken cancellationToken)
        {
            return await repository.GetAll();
        }
    }
}
