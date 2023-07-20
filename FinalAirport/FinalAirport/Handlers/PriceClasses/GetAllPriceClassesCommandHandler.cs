using FinalAirport.Commands.PriceClasses;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.PriceClasses
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
